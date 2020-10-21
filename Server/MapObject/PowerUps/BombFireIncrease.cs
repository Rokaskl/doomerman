using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class BombFireIncrease : Pickable
    {
        public BombFireIncrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUIncreaseBombRange;
        }
        public BombFireIncrease():base()
        {

        }
    }
}
