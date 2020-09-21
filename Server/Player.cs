using Newtonsoft.Json;
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
        public Player(User user)
        {
            this.User = user;
            this.xy = new Coordinates();
            this.sender = new Sender(user);
        }

        public bool CanMove(CommandEnum cmd)
        {
            switch (cmd)
            {
                case CommandEnum.MoveUp:
                    {
                        return xy.Y > 0;
                    }
                case CommandEnum.MoveDown:
                    {
                        return xy.Y < 13;
                    }
                case CommandEnum.MoveRight:
                    {
                        return xy.X < 13;
                    }
                case CommandEnum.MoveLeft:
                    {
                        return xy.X > 0;
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
            this.Bomb = new Explosive();//unnecessary, could use explosives list/enum/etc.
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

            string json = JsonConvert.SerializeObject(clientData);

            sender.Send(json);
        }
    }
}
