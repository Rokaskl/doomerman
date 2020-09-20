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
            TcpClient client = new TcpClient(ip, port);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Listener serverListener = new Listener(client);

            }).Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(client));

            Console.ReadLine();

        }
    }
}
