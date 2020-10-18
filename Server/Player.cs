using Newtonsoft.Json;
using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Player : IPlayer
    {
        public User User;
        public Coordinates xy;
        public Explosive Bomb;
        public Sender sender;
        public int Score = 0;
        public bool Alive = true;
        public List<Pickable> PowerUps { get; set; }
        public Player(User user)
        {
            this.User = user;
            this.xy = new Coordinates();
            this.Bomb = new Explosive();
            this.sender = new Sender(user);
        }

        public bool CanMove(ArenaCommandEnum cmd, int[,] walls)
        {
            switch (cmd)
            {
                case ArenaCommandEnum.MoveUp:
                    {
                        return xy.Y > 0 && walls[xy.X,xy.Y-1] == 0;
                    }
                case ArenaCommandEnum.MoveDown:
                    {
                        return xy.Y < 12 && walls[xy.X, xy.Y + 1] == 0;
                    }
                case ArenaCommandEnum.MoveRight:
                    {
                        return xy.X < 12 && walls[xy.X+1, xy.Y] == 0;
                    }
                case ArenaCommandEnum.MoveLeft:
                    {
                        return xy.X > 0 && walls[xy.X-1, xy.Y] == 0;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public bool CanDropBomb()
        {
            return true;//Should prevent continuous dropping.
        }

        public void DropBomb()
        {
            this.Bomb.SetCords(xy);
            this.Bomb.Droped = false;
            
        }
        public void AddPowerUp(Pickable item)
        {
            this.PowerUps.Add(item);
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
        public void Update(Grid grid)
        {
            ClientData clientData = new ClientData();
            clientData.Grid = grid.GetGrid();
            clientData.Id = this.User.Id;
            clientData.Score = this.Score;
            clientData.Alive = this.Alive;
            clientData.BombRadius = (this.Bomb as Explosive).Radius;

            string json = JsonConvert.SerializeObject(clientData);

            sender.Send(json);
        }

    }
}
