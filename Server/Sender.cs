using System;
using System.Collections.Generic;
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

        public void Send (string message)
        {
            NetworkStream stream = this.client.GetStream();
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }
    }

}
