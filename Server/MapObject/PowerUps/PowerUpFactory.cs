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
                case 0:
                    return new BombKick(new GameObject(xy));
                case 1:
                    return new BombLimitIncrease(new GameObject(xy));
                case 2:
                    return new ExplosionTimeDecrease(new GameObject(xy));
                case 3:
                    return new ExtraLife(new GameObject(xy));
                case 4:
                    return new FireIncrease(new GameObject(xy));
                case 5:
                    return new SpeedIncrease(new GameObject(xy));
                case 6:
                    return new TemporaryJump(new GameObject(xy));
                case 7:
                    return new TemporarySwim(new GameObject(xy));

                default: return null;
            }
        }
           
    }
}
