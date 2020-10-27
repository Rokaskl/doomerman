using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class BombLimitIncrease : Pickable
    {
        public BombLimitIncrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUIncreaseBombLimit;
        }
        public BombLimitIncrease() : base()
        {

        }
    }
}
