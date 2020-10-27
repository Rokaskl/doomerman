using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class TemporaryJump : Pickable
    {
        public TemporaryJump(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUTemporaryJump;
        }

        public TemporaryJump() : base()
        {

        }
    }
}
