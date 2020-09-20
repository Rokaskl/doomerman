using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;

namespace OPP
{
    class Listener
    {
       public Listener(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                //Listening Server
                while (true)
                {
                    // Bytes Array to receive Server Response.
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    //---read incoming stream---
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received : " + dataReceived);
                }


                // Before closing client
                // stream.Close();
                // client.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }
      

    } 
}