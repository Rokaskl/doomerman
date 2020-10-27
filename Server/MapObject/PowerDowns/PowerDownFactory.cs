using System;
using System.Collections.Generic;
using System.Text;
using Server.constants;
using Server.MapObject.PowerDowns;

namespace Server.MapObject.PowerUps
{
   public class PowerDownFactory  : IAbstractPickableFactory
    {
        public Pickable Build(int which, Coordinates xy)
        {
            switch(which)
            {
                case 0:
                    return new BombFireDecrease(new GameObject(xy));
                case 1:
                    return new BombLimitDecrease(new GameObject(xy));
                case 2:
                    return new AutoPlacer(new GameObject(xy));

                default: return null;
            }
        }
        public Pickable GetRandom(Coordinates cords)
        {
            return this.Build(Constants.next(0,2), cords);
        }

    }
}
