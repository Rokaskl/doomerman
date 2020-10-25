using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.Builder
{
    class PlayerBuilder : Builder
    {
        private User user;
        private Player player;
        public override void BuildData(TcpClient client)
        {
            byte[] buffer = new byte[client.Available];

            client.GetStream().Read(buffer, 0, client.Available);
            int userId = BitConverter.ToInt32(buffer, 4);
            user = App.Inst.UserRepo.Users.FirstOrDefault(x => x.Id == userId);//Reikia suziureti id
            if (user != null)
            {
                user.Client = client;
            }
            else
            {
                user = App.Inst.UserRepo.AddUser(new User(userId));
                user.Client = client;
            }
            Console.WriteLine("Client " + user.Id.ToString() + "connected."); ;
        }

        public override void BuildMainObject()
        {
            player = new Player(user);
        }

        public override Player GetPlayer()
        {
            return player;
        }
    }
}
