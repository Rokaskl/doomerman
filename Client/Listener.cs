using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
namespace OPP
{
    class Listener
    {
       public Listener(String server, Int32 port)
        {
            Connect(server, port);
        }
        static void Connect(String server,  Int32 port)
        {
            try
            {
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                //Listening Server
                while (true)
                {
                    // Bytes Array to receive Server Response.
                    Byte[] data = new Byte[256];
                    String response = String.Empty;

                    // Read the Tcp Server Response Bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", response);

                    Thread.Sleep(10);
                }


                // Before closing client
                // stream.Close();
                // client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }

            Console.Read();
        }
    }
   
}
