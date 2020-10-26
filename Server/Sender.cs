using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Server
{
    public class Sender
    {
        private TcpClient client;
        public Sender(User user)
        {
            this.client = user.Client;
        }

        public void Send (int num, string message)
        {
            try
            {
                //Try, finallize commands undo.
                NetworkStream stream = this.client.GetStream();
                StreamWriter wr = new StreamWriter(stream);
                
                    //byte[] numBytes = BitConverter.GetBytes(num);
                    //byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                    //var bytes = new byte[numBytes.Length + messageBytes.Length];
                    //numBytes.CopyTo(bytes, 0);
                    //messageBytes.CopyTo(bytes, numBytes.Length);
                    wr.WriteLine(num.ToString() + message);
                    wr.Flush();
                
            }
            catch(Exception e)
            {

            }
         
        }
    }

}
