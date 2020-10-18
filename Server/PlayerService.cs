using Server.CommandPattern;
using Server.FacadePattern;
using Server.GameLobby;
using Server.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public  class PlayerService
    {
        public PlayerService(Player player, LogicFacade logic)
        {
            Task.Run(() => ListenPlayer(player, logic));
        }
        
        public async void ListenPlayer(Player player, LogicFacade logic)
        {
            try
            {
                Console.WriteLine("Player " + player.User.Id + " added.");
                var stream = player.User.Client.GetStream();
                while (true)
                {
                    await Task.Delay(5);

                    if (stream.DataAvailable && player.User.Client.Available >= 12)
                    {
                        int available = player.User.Client.Available;
                        byte[] buffer = new byte[available];
                        stream.Read(buffer, 0, available);
                        if (buffer.Length > 8)
                        {
                            int index = 1;
                            int commandType = BitConverter.ToInt32(buffer, 0);
                            Command cmd = null;
                            switch (commandType)
                            {
                                case 1:
                                    {
                                        cmd = new ArenaCommand { Author = player, TimeStamp = DateTime.UtcNow };
                                        break;
                                    }
                                case 0:
                                    {
                                        cmd = new GeneralCommand { Author = player, TimeStamp = DateTime.UtcNow };
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                           
                            while (buffer.Length >= (index + 1) * 4 + 4)
                            {
                                cmd.AddSubCommand(BitConverter.ToInt32(buffer, (index + 1) * 4));
                                index++;
                            }
                            logic.AddCommand(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
