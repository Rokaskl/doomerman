using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
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
        private Grid grid;
        private GameLogic Calculator;
        public GameArena(int id)
        {
            this.Id = id;
            this.Players = new List<Player>();
            this.Calculator = new GameLogic(this);
            this.grid = new Grid();
            //StartGame();
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
            Task.Run(() => PlayerService(player));
        }

        public async void PlayerService(Player player)
        {

            try
            {
                Console.WriteLine("Player " + player.User.Id + " added.");
                var stream = player.User.Client.GetStream();
                while (true)
                {
                    await Task.Delay(5);

                    if (stream.DataAvailable)
                    {
                        int available = player.User.Client.Available;
                        byte[] buffer = new byte[available];
                        stream.Read(buffer, 0, available);
                        if (buffer.Length > 8)
                        {
                            var cmd = new Command { Author = player, TimeStamp = DateTime.UtcNow };
                            int index = 1;
                            while (buffer.Length >= (index + 1) * 4 + 4)
                            {
                                cmd.Cmds.Add((CommandEnum)BitConverter.ToInt32(buffer, (index + 1) * 4));
                                index++;
                            }
                            //cmd.Execute();
                            Calculator.AddCommand(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Notify()
        {
            foreach (Player player in Players)
            {
                player.Update(this.grid);
            }

        }
        public void UpdateGrid()
        {
            grid.Clean();
            foreach(Player player in Players)
            {
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
            }
           Notify();

        }
        //public void StartGame()
        //{
        //    Task.Run(async () =>
        //    {
        //        try
        //        {


        //            Console.WriteLine("Arena started");
        //            while (true)
        //            {
        //                await Task.Delay(5);
        //                //Player player = this.Players.FirstOrDefault(player => player.User.Client.GetStream().CanRead && player.User.Client.Available >= 8);
        //                //Player player = this.Players.FirstOrDefault(player => player.User.Client.GetStream().CanRead && player.User.Client.Available >= 8);
        //                //while (true)
        //                //{
        //                this.Players.ToList().ForEach(player =>
        //                {
        //                    var stream = player.User.Client.GetStream();
        //                    if (stream.DataAvailable && player.User.Client.Available >= 8)
        //                    {
        //                        byte[] buffer = new byte[player.User.Client.Available];
        //                        Console.WriteLine(player.User.Client.Available.ToString());
        //                        stream.Read(buffer, 0, player.User.Client.Available);

        //                        //int userId = BitConverter.ToInt32(buffer, 4);
        //                        //Server.User user = App.Inst.UserRepo.Users.FirstOrDefault(x => x.Id == userId);//Reikia suziureti id
        //                        //if (user != null)
        //                        //{
        //                        //    user.Client = client;
        //                        //}
        //                        //else
        //                        //{
        //                        //    user = App.Inst.UserRepo.AddUser(new User());
        //                        //}
        //                        //Arena.Players.Add(user);
        //                        //else jei userio nera.
        //                        if (buffer.Length > 8)
        //                        {
        //                            var cmd = new Command { Author = player, TimeStamp = DateTime.UtcNow };
        //                            int index = 1;
        //                            while (buffer.Length >= (index + 1) * 4 + 4)
        //                            {
        //                                cmd.Cmds.Add((CommandEnum)BitConverter.ToInt32(buffer, (index + 1) * 4));
        //                                index++;
        //                            }
        //                            cmd.Execute();
        //                        }
        //                        //break;
        //                        //}
        //                    }
        //                });


        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    });
        //}
    }
}
