
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;


namespace Server
{
    //public static class App
    //{
    //    public static Inst Inst;
    //    public static void CreateInst(AppOptions options)
    //    {
    //        Inst = new Inst(options);
    //    }
    //}
    //public class Inst
    //{

    //    public UserRepository UserRepo { get; set; }
    //    public GameArena Arena; 
    //    public AppOptions Options;
    //    public Inst(AppOptions options)
    //    {
    //        this.UserRepo = new UserRepository();
    //        this.Options = options; 
    //        this.Arena = new GameArena(options.ArenaId);
    //    }

    //    public void CreateListener()
    //    {
    //        Thread listenerThread = new Thread(() =>
    //        {
    //            Listener listener = new Listener(Options.Ip, Options.Port,Arena);
    //        });
    //        listenerThread.Start();

    //        Console.WriteLine("Server Listening On {0} : {1}", Options.Ip ,Options.Port);
    //    }



    //}

    public static class App
    {
        public static object threadLock = new object();
        public static Application Inst = null;
        public static Application CreateInstance(AppOptions options)
        {
            lock (threadLock)
            {
                if (Inst == null)
                {
                    Inst = new ApplicationInst(options);
                    Inst.Log("singleton created.");
                }
                else
                {
                    throw new MethodAccessException("Instance cannot be created twice");
                }
            }
           
            return Inst;
        }

        public class Application
        {

            private AppOptions options = null;
            public AppOptions Options
            {
                get
                {
                    if (options == null)
                    {
                        throw new Exception("Options are not set");
                    }
                    else
                    {
                        return this.options;
                    }
                }
            }

            public UserRepository UserRepo { get; set; }
            public GameArena Arena;

            public void CreateListener()
            {
                Thread listenerThread = new Thread(() =>
                {
                    Listener listener = new Listener(Options.Ip, Options.Port, Arena);
                });
                listenerThread.Start();

                Console.WriteLine("Server Listening On {0} : {1}", Options.Ip, Options.Port);
            }

            protected Application(AppOptions options)
            {
                this.UserRepo = new UserRepository();
                this.options = options;
                this.Arena = new GameArena(options.ArenaId);
            }

            public void Log(string message)
            {
                Console.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        private class ApplicationInst : Application
        {
            public ApplicationInst(AppOptions options) : base(options)
            { }
        }
    }
}

