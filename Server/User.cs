using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class User
    {
        private static int counter = 1;
        public int Id;
        public string Username;
        public TcpClient Client { get; set; }
        public User(int id = 0, string username = null)
        {
            if(id == 0)
            {
                this.Id = counter++;
            }
            else
            {
                this.Id = id;
            }
            
            this.Username = username ?? ("user" + (counter - 1).ToString()); 
        }

    }
}
