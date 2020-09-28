
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
    public static class App
    {
        public static Inst Inst;
        public static void CreateInst(AppOptions options)
        {
            Inst = new Inst(options);
        }
    }
    public class Inst
    {
       
        public UserRepository UserRepo { get; set; }
        public GameArena Arena; 
        public AppOptions Options;
        public Inst(AppOptions options)
        {
           
            this.UserRepo = new UserRepository();
            this.Options = options; 
            this.Arena = new GameArena(options.ArenaId);
        }

        public void CreateListener()
        {
            Thread listenerThread = new Thread(() =>
            {
                Listener listener = new Listener(Options.Ip, Options.Port,Arena);
            });
            listenerThread.Start();

            Console.WriteLine("Server Listening On {0} : {1}", Options.Ip ,Options.Port);
        }
       

    
    }
}

