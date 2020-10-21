using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class PowerUpFactory : IAbstractPickableFactory
    {
        public Pickable Build(int which, Coordinates xy)
        {
            switch(which)
            {
                //case 0:
                //    return new BombKick(new GameObject(xy));
                case 0:
                    return new BombLimitIncrease(new GameObject(xy));
                //case 2:
                //    return new ExtraLife(new GameObject(xy));
                case 1:
                    return new BombFireIncrease(new GameObject(xy));
                //case 4:
                //    return new SpeedIncrease(new GameObject(xy));
                //case 5:
                //    return new TemporaryJump(new GameObject(xy));
                //case 6:
                   // return new TemporarySwim(new GameObject(xy));

                default: return null;
            }
        }
     
        public Pickable GetRandom(Coordinates cords)
        {
            int random = Program.random.Next(0,2);
            Console.WriteLine(random);
            return this.Build(random, cords);
        }
    }
}
