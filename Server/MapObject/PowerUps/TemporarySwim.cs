using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class TemporarySwim : Pickable
    {
        public TemporarySwim(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUTemporarySwim;
        }

        public TemporarySwim() : base(){

        }
    }
}
