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
        public GameObject Bomb;
        public Sender sender;
        public int Score = 0;
        public bool Alive = true;
        public List<Pickable> PowerUps { get; set; }
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
                        return xy.Y < 12;
                    }
                case CommandEnum.MoveRight:
                    {
                        return xy.X < 12;
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
            GameObject gameObject = new GameObject();
            gameObject.xy = this.xy;
            this.Bomb = new Explosive(gameObject);//unnecessary, could use explosives list/enum/etc.
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

            string json = JsonConvert.SerializeObject(clientData);

            sender.Send(json);
        }
    }
}
