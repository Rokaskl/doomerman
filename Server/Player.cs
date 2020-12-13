using Newtonsoft.Json;
using Server.CommandPattern;
using Server.GameLobby;
using System;
using System.Collections.Generic;
using System.Text;
using Server.constants;
using static Server.TileEnumerator;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Linq;
using Server.Mediator;
using Server.FacadePattern;

namespace Server
{
    public class Player : IColleague, IPlayer
    {
        public User User;
        public Coordinates xy;
        public Explosive Bomb;
        public int BombCount = 0;
        public int BombLimit = Constants.StartBombLimit;
        public Sender sender;
        public int Score = 0;
        public bool Alive = true;
        public bool Ready { get; set; }
        public Lobby PlayerLobby { get; set; }
        public List<Pickable> PowerUps { get; set; }
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

        public IMoveStrategy moveStrategy = new MoveNormalStrategy();
        public Player(User user)
        {
            this.User = user;
            this.xy = new Coordinates();
            this.Bomb = new Explosive();
            this.sender = new Sender(user);
            this.PowerUps = new List<Pickable>();
        }

        public bool CanMove(ArenaCommandEnum cmd, List<int>[,] walls)
        {
 
            
            switch (cmd)
            {
                case ArenaCommandEnum.MoveUp:
                    {
                        return xy.Y > 0 && CheckMove(walls, xy.X, xy.Y - 1);
                    }
                case ArenaCommandEnum.MoveDown:
                    {
                        return xy.Y < 12 && CheckMove(walls, xy.X, xy.Y + 1);
                    }
                case ArenaCommandEnum.MoveRight:
                    {
                        return xy.X < 12 && CheckMove(walls, xy.X + 1, xy.Y);
                    }
                case ArenaCommandEnum.MoveLeft:
                    {
                        return xy.X > 0 && CheckMove(walls, xy.X - 1, xy.Y);
                    }
                default:
                    {
                        return false;
                    }
            }
                    
            
        }
        private bool CheckMove(List<int>[,] walls, int x, int y)
        {
            if (moveStrategy is MoveNormalStrategy)
            {

                var values = new List<int> { (int)TileTypeEnum.Wall, (int)TileTypeEnum.Bomb, (int)TileTypeEnum.DestroyableWall, (int)TileTypeEnum.Water };
                for (int i = 0; i < values.Count; i++)
                {
                    if (walls[x,y].Contains(values[i]))
                        return false;
                }
                return true;
            }
            else if (moveStrategy is MoveKickStrategy)
            {
                var values = new List<int> { (int)TileTypeEnum.Wall, (int)TileTypeEnum.DestroyableWall, (int)TileTypeEnum.Water };
                for (int i = 0; i < values.Count; i++)
                {
                    if (walls[x,y].Contains(values[i]))
                        return false;
                }

                if (walls[x,y].Contains((int)TileTypeEnum.Bomb))
                {
                    Explosive.KickDirection direction = Explosive.KickDirection.Down;

                    if(xy.X < x)
                    {
                        direction = Explosive.KickDirection.Right;
                    }
                    else if(xy.X > x)
                    {
                        direction = Explosive.KickDirection.Left;
                    }
                    else if(xy.Y < y)
                    {
                        direction = Explosive.KickDirection.Down;
                    }
                    else if(xy.Y > y)
                    {
                        direction = Explosive.KickDirection.Up;
                    }

                    return App.Inst.Arena.KickBomb(new Coordinates(x, y), direction);
                    
                }

                return true;

            }
            else if (moveStrategy is MoveSwimStrategy)
            {
                var values = new List<int> { (int)TileTypeEnum.Wall, (int)TileTypeEnum.Bomb, (int)TileTypeEnum.DestroyableWall };
                for (int i = 0; i < values.Count; i++)
                {
                    if (walls[x,y].Contains(values[i]))
                        return false;
                }
                return true;
            }
            else if (moveStrategy is MoveJumpStrategy)
            {
                var values = new List<int> { (int)TileTypeEnum.Wall, (int)TileTypeEnum.DestroyableWall, (int)TileTypeEnum.Water };
                for (int i = 0; i < values.Count; i++)
                {
                    if (walls[x,y].Contains(values[i]))
                        return false;
                }
                return true;
            }
            
            return false;
        }
        public bool CanDropBomb()
        {
            return true;//Should prevent continuous dropping.
        }

        public void DropBomb()
        {
            this.Bomb.SetCords((Coordinates)xy.Clone());
            this.Bomb.Droped = false;

        }

        public void ChangeStrategy(IMoveStrategy strategy)
        {
            moveStrategy = strategy; 
        }

        public void AddPowerUp(Pickable item)
        {
            this.PowerUps.Add(item);

            switch (item.type)
            {
                case TileEnumerator.TileTypeEnum.PUTemporaryJump:
                    moveStrategy = new MoveJumpStrategy();
                    break;

                case TileEnumerator.TileTypeEnum.PUTemporarySwim:
                    moveStrategy = new MoveSwimStrategy();
                    break;

                case TileEnumerator.TileTypeEnum.PUBombKick:
                    moveStrategy = new MoveKickStrategy();
                    break;
            }
        }
        public void MoveUp()
        {
            this.xy.Y--;
        }

        public void MoveDown()
        {
            this.xy.Y++;
        }

        public void MoveRight()
        {
            this.xy.X++;
        }

        public void MoveLeft()
        {
            this.xy.X--;
        }
        public void Update(Grid grid, List<int> deadPlayers)
        {
            ClientData clientData = new ClientData();
            clientData.Grid = grid.GetGrid();
            clientData.Id = this.User.Id;
            clientData.Score = this.Score;
            clientData.Alive = this.Alive;
            clientData.BombRadius = (this.Bomb as Explosive).Radius;
            clientData.DeadPlayers = deadPlayers.ToArray();

            string json = JsonConvert.SerializeObject(clientData);

            sender.Send(0, json);
            Console.WriteLine(DateTime.Now);
        }
        public void IncBombLimit()
        {
            if (BombLimit < Constants.MaxBombLimit)
                BombLimit++;
        }
        public void DecBombLimit()
        {
            if (BombLimit > 1)
                BombLimit--;
        }

        public void StartListenerService(LogicFacade logic)
        {
            this.mediator.ExecuteCommand("Listen", this.BondedColleague, logic);
        }
    }
}
