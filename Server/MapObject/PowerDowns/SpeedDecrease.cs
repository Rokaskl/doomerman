﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    class SpeedDecrease : Pickable
    {
        public SpeedDecrease(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUDecreaseSpeed;
        }
    }
}