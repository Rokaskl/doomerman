using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace OPP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Int32 port = 13000;
            string ip = "127.0.0.1";
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
            Listener serverListener= new Listener(ip, port);

            }).Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Console.ReadLine();

        }
    }
}
