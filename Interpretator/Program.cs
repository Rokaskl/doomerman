using System;
using System.Net.Sockets;

namespace Interpretator
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 13001);

            client.Connect("127.0.0.1", 13000);


        }
    }
}
