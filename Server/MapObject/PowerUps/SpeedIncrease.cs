using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class SpeedIncrease : Pickable
    {
        public SpeedIncrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUIncreaseSpeed;
        }
    }
}
