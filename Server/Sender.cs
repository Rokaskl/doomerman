using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
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
            NetworkStream nwStream = this.client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }

}
