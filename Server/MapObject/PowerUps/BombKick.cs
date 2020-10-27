using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class BombKick : Pickable
    {
        public BombKick(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUBombKick;
        }
        public BombKick() : base()
        {

        }
    }
}
