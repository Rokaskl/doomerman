using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public  class PlayerService
    {
        public PlayerService(Player player, GameLogic Calculator)
        {
            Task.Run(() => ListenPlayer(player, Calculator));
        }
        
        public async void ListenPlayer(Player player, GameLogic Calculator)
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
                            var cmd = new Command { Author = player, TimeStamp = DateTime.UtcNow };
                            int index = 1;
                            while (buffer.Length >= (index + 1) * 4 + 4)
                            {
                                cmd.Cmds.Add((CommandEnum)BitConverter.ToInt32(buffer, (index + 1) * 4));
                                index++;
                            }
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
    }
}
