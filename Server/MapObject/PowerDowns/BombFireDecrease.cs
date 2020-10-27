using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class BombFireDecrease : Pickable
    {
        public BombFireDecrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUDecreaseBombRange;
        }
        public BombFireDecrease():base()
        {

        }
    }
}
