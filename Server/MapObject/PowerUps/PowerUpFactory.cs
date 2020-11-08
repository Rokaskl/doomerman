using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class PowerUpFactory : IAbstractPickableFactory
    {
        public Pickable Build(int which, Coordinates xy)
        {
            switch(which)
            {
                case 0:
                    return new BombKick(new GameObject(xy));
                case 1:
                    return new BombLimitIncrease(new GameObject(xy));
                //case 2:
                //    return new ExtraLife(new GameObject(xy));
                case 2:
                    return new BombFireIncrease(new GameObject(xy));
                //case 4:
                //    return new SpeedIncrease(new GameObject(xy));
                case 3:
                    return new TemporaryJump(new GameObject(xy));
                case 4:
                    return new TemporarySwim(new GameObject(xy));

                default: return null;
            }
        }
     
        public Pickable GetRandom(Coordinates cords)
        {
            int random = new Random().Next(0, 5);
            Console.WriteLine(random);
            return this.Build(random, cords);
        }
    }
}
