﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject.PowerUps
{
    public class ExtraLife : Pickable
    {
        public ExtraLife(GameObject gm) : base(gm)
        {
            type = TileEnumerator.TileTypeEnum.PUExtraLife;
        }
    }
}
