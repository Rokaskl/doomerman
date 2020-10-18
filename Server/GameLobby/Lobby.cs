using Newtonsoft.Json;
using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Server.GameLobby
{
    public class Lobby
    {
        private const int _maxPlayerCount = 4;
        private List<Player> players;
        private List<GeneralCommand> readyCommands;
        public Lobby()
        {
            this.players = new List<Player>();
            this.readyCommands = new List<GeneralCommand>();
        }

        public bool AddPlayer(Player player)
        {
            if(this.players.Count < _maxPlayerCount)
            {
                this.players.Add(player);
                player.PlayerLobby = this;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        public bool PlayerReady(GeneralCommand command)
        {
            if(!this.readyCommands.Contains(command) && this.readyCommands.Count < _maxPlayerCount)
            {
                command.Author.Ready = true;
                this.readyCommands.Add(command);
                return true;
            }
            else
            {
                return false;
            }
        }
        //command undo...
        public void PlayerNotReady(Player player)
        {
            if(this.readyCommands.Any(x => x.Author == player))
            {
                this.readyCommands.RemoveAll(x => x.Author == player);
                player.Ready = false;
            }
        }

        public GeneralCommand GetReadyCommand(Player player)
        {
            return this.readyCommands.FirstOrDefault(x => x.Author == player);
        }

        private string FormData()
        {
            var data = this.players.Select(x => new KeyValuePair<int, bool>(x.User.Id, this.readyCommands.Any(y => y.Author == x)));
            return JsonConvert.SerializeObject(data);
        }

        public void SendInfo()
        {
            var formedData = FormData();

            //debug
            Console.WriteLine(formedData);
            //

            this.players.ForEach(x => x.sender.Send(formedData));
        }
    }
}
