using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class AutoPlacer : Pickable
    {
        public AutoPlacer(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUAutoPlacer;
        }
    }
}
