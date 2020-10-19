using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class TemporaryJump : Pickable
    {
        public TemporaryJump(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUTemporaryJump;
        }
    }
}
