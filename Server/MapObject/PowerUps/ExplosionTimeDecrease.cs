using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class ExplosionTimeDecrease : Pickable
    {
        public ExplosionTimeDecrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime;
        }
    }
}
