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

        public Player(User user)
        {
            this.User = user;
            this.xy = new Coordinates();
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
            Console.WriteLine("Notified {0} of Grid update " ,User.Id );
            //Send grid for player
        }
    }
}
