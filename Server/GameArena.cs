using Microsoft.VisualBasic.FileIO;
using Server.FacadePattern;
using Server.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.GameLobby;
using Server.MapObject;
using Newtonsoft.Json;
using static Server.TileEnumerator;
using Server.MapObject.PowerUps;
using Server.constants;
using Server.MapObject.PowerDowns;
using System.IO;
using Server.ChainOfRespPattern;
using Server.Iterator;
using Server.Mediator;

namespace Server
{
    public class GameArena : Arena, IGameArenaObserver, IColleague
    {
        public int Id;
        private LogicFacade Calculator;
        private IHandler updateHandler;
        private Lobby lobby;
        public Walls wallsObj = new Walls();
        public bool isStarted = false;
        private IMediator mediator;

        public IMediator Mediator
        {
            get => this.mediator;
            set => this.mediator = value;
        }
        private IColleague colleague;
        public IColleague BondedColleague
        {
            get => this.colleague;
            set
            {
                this.colleague = value;
                if (this.colleague != null && this.colleague.BondedColleague == null)
                {
                    this.colleague.BondedColleague = this;
                }
            }
        }

        public GameArena(int id)
        {
            this.Id = id;
            this.Players = new Aggregate<Player>();
            this.lobby = new Lobby(this);
            this.Calculator = new LogicFacade(this, lobby);
            this.mediator = new PlayerMediator();
            this.grid = new WallsAdapter(wallsObj);
            walls = wallsObj.GetWalls();
            SetupHandlerChain();
            UpdateAtInterval(Constants.UpdateInterval);
        }
        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
            player.sender.Send(1, player.User.Id.ToString());//Answer to handshake
            var serviceColleague = new PlayerServiceProxyColleague();
            serviceColleague.BondedColleague = player;
            this.mediator.Register(serviceColleague);
            player.StartListenerService(this.Calculator);
        }

        public void Notify()
        {

            Players.CreateIterator().ForEach(player =>
            {
                player.Update(this.grid, DeadPlayers());
            });
        }
        public List<int> DeadPlayers()
        {
            var deads = new List<int>();
            Players.CreateIterator().ForEach(x =>
            {
                if (!x.Alive) deads.Add(x.User.Id);
            });
            return deads;
        }
        public void StartGame()
        {
            isStarted = true;
            UpdateRequired = true;
        }

        public bool KickBomb(Coordinates bombCord, Explosive.KickDirection dir)
        {
            List<int> cantKickInto = new List<int>() { (int)TileTypeEnum.Wall, (int)TileTypeEnum.DestroyableWall, (int)TileTypeEnum.Water, (int)TileTypeEnum.Bomb };

            foreach (var go in gameObjects)
            {
                if (go.GetCords().X == bombCord.X && go.GetCords().Y == bombCord.Y)
                {
                    if (go is Explosive)
                    {
                        switch (dir)
                        {
                            case Explosive.KickDirection.Up:
                                if (go.GetCords().Y > 0 && !cantKickInto.Contains(walls[go.GetCords().X, go.GetCords().Y - 1]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X, go.GetCords().Y - 1));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);

                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Down:

                                if (go.GetCords().Y < 12 && !cantKickInto.Contains(walls[go.GetCords().X, go.GetCords().Y + 1]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X, go.GetCords().Y + 1));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Left:
                                if (go.GetCords().X > 0 && !cantKickInto.Contains(walls[go.GetCords().X - 1, go.GetCords().Y]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X - 1, go.GetCords().Y));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Right:
                                if (go.GetCords().X < 12 && !cantKickInto.Contains(walls[go.GetCords().X + 1, go.GetCords().Y]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X + 1, go.GetCords().Y));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                        }
                    }
                }
            }

            return false;
        }

        private void SetupHandlerChain()
        {
            var handler = new PowersHandler<GameArena>(this);
            handler
                .SetSuccessor(new CleanGridHandler<GameArena>(this))
                .SetSuccessor(new WallsHandler<GameArena>(this))
                .SetSuccessor(new PlayersAndBombsHandler<GameArena>(this))
                .SetSuccessor(new GameObjectsHandler<GameArena>(this))
                .SetSuccessor(new FlamesHandler<GameArena>(this));
            this.updateHandler = handler;
            App.Inst.Log("Chain of responsibility setup");
        }

        public void UpdateGrid()
        {
            App.Inst.Log("Chain of responsibility executed update handlers chain.");
            this.updateHandler.HandleRequest();
            Notify();
            // Save grid to stack
            UpdateRequired = false;
        }
        
        private async void UpdateAtInterval(int timeout)
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (UpdateRequired)
                        UpdateGrid();

                    Thread.Sleep(timeout);
                }
            });
        }
    }
}
