using Newtonsoft.Json;
using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.GameLobby
{
    public class Lobby
    {
        private const int _maxPlayerCount = 4;
        private List<Player> players;
        private List<GeneralCommand> readyCommands;
        public bool isStarting = true;
        private DateTime? startingAt;
        private CancellationToken? token;
        private CancellationTokenSource source;
        private GameArena arena;
        public Lobby(GameArena arena)
        {
            this.arena = arena;
            this.players = new List<Player>();
            this.readyCommands = new List<GeneralCommand>();
            this.source = new CancellationTokenSource();
        }

        public virtual bool AddPlayer(Player player)
        {
            if(this.players.Count < _maxPlayerCount && !this.players.Contains(player))
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

        public virtual void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        public virtual bool PlayerReady(GeneralCommand command)
        {
            if(!this.readyCommands.Contains(command) && this.readyCommands.Count < _maxPlayerCount)
            {
                command.Author.Ready = true;
                this.readyCommands.Add(command);
                if(this.readyCommands.Count>= 2)
                {
                    StartCountdown();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //command undo...
        public virtual void PlayerNotReady(Player player)
        {
            if(this.readyCommands.Any(x => x.Author == player))
            {
                this.readyCommands.RemoveAll(x => x.Author == player);
                player.Ready = false;
                if (this.isStarting)
                {
                    CancelCountdown();
                }
            }
        }

        public virtual GeneralCommand GetReadyCommand(Player player)
        {
            return this.readyCommands.FirstOrDefault(x => x.Author == player);
        }

        private string FormData()
        {
            //var data = this.players.Select(x => new KeyValuePair<int, bool>(x.User.Id, this.readyCommands.Any(y => y.Author == x)));
            var data = new LobbyData();
            this.players.ForEach(x =>
            {
                data.playerData.Add(x.User.Id.ToString(), this.readyCommands.Any(y => y.Author == x));
            });
            data.Starting = this.isStarting;
            data.GameStartsAt = this.startingAt;
            return JsonConvert.SerializeObject(data);
        }

        public virtual void SendInfo()
        {
            var formedData = FormData();

            //debug
            Console.WriteLine(formedData);
            //

            this.players.ForEach(x => x.sender.Send(2, formedData));
        }

        private void CancelCountdown()
        {
            this.source.Cancel();
           // SendInfo();//Todo remove from here
        }

        private void StartCountdown()
        {
            this.token = source.Token;
            
            Task.Run(() =>
            {
                this.isStarting = true;
                this.startingAt = DateTime.Now + TimeSpan.FromMilliseconds(5000);
                Task.Delay(5000);
                Console.WriteLine("Game started!");
                this.arena.StartGame();
                this.isStarting = false;
                this.startingAt = null;
            }, (CancellationToken)this.token);
        }
    }
}
