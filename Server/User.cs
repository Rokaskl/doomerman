using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class User
    {
        public static int counter = 1;
        public int Id;
        public string Username;
        private TcpClient client;
        public TcpClient Client
        {
            get => client;
            set => client = value;
        }

        public User(string username = null)
        {
            this.Id = counter++;
            this.Username = username ?? ("user" + (counter - 1).ToString()); 
        }

    }
}
