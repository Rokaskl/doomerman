using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerDowns
{
    public class BombLimitDecrease : Pickable
    {
        public BombLimitDecrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUDecreaseBombLimit;
        }
        public BombLimitDecrease() : base()
        {

        }
    }
}
