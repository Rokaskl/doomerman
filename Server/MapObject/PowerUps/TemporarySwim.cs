using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class TemporarySwim : Pickable
    {
        public TemporarySwim(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUTemporarySwim;
        }
    }
}
