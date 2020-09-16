using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GameArena
    {
        //Game arena is 13x13 tiles.
        public int Id;
        public List<Player> Players;
        private GameLogic Calculator;

        public GameArena(int id)
        {
            this.Id = id;
            this.Players = new List<Player>();
            this.Calculator = new GameLogic();
            StartGame();
        }

        public void StartGame()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(5);
                    Player player = this.Players.FirstOrDefault(player => player.User.Client.GetStream().CanRead && player.User.Client.Available >= 8);
                    //while (true)
                    //{

                    if (player != null)
                    {
                        byte[] buffer = new byte[player.User.Client.Available];
                        player.User.Client.GetStream().Read(buffer, 0, player.User.Client.Available);
                            //int userId = BitConverter.ToInt32(buffer, 4);
                            //Server.User user = App.Inst.UserRepo.Users.FirstOrDefault(x => x.Id == userId);//Reikia suziureti id
                            //if (user != null)
                            //{
                            //    user.Client = client;
                            //}
                            //else
                            //{
                            //    user = App.Inst.UserRepo.AddUser(new User());
                            //}
                    //Arena.Players.Add(user);
                    //else jei userio nera.
                    if (buffer.Length > 8)
                    {
                        var cmd = new Command { Author = player, TimeStamp = DateTime.UtcNow };
                        int index = 1;
                        while (buffer.Length >= (index + 1) * 4 + 4)
                        {
                            cmd.Cmds.Add((CommandEnum)BitConverter.ToInt32(buffer, (index + 1) * 4));
                            index++;
                        }
                        cmd.Execute();
                    }
                    //break;
                    //}
                    }
                }
            });
        }
    }
}
