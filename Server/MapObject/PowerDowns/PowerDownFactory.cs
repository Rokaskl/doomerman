using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class PowerDownFactory  : AbstractPickableFactory
    {
        public Pickable Build(int which, Coordinates xy)
        {
            switch(which)
            {
                case 0:
                    return new BombFireDecrease(new GameObject(xy));
                case 1:
                    return new AutoPlacer(new GameObject(xy));
                case 2:
                    return new SpeedDecrease(new GameObject(xy));

                default: return null;
            }
        }
           
    }
}
