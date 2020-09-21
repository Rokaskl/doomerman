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
                    byte[] bytes = new byte[client.ReceiveBufferSize];
                    stream.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes);
                    Data data = JsonConvert.DeserializeObject<Data>(msg);
                    Console.WriteLine(data.Grid);
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