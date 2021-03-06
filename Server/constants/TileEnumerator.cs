﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class TileEnumerator
    {
        public enum TileTypeEnum
        {
            Empty,
            Player1,
            Player2,
            Player3,
            Player4,
            Bomb,
            Wall,
            Crate,
            PUIncreaseBombRange,
            PUDecreaseBombRange,
            PUIncreaseBombLimit,
            PUDecreaseBombLimit,
            PUTemporaryShield,
            PUTemporaryJump,
            DestroyableWall,
            PUExtraLife,
            PUIncreaseSpeed,
            PUDecreaseSpeed,
            PUBombKick,
            PUDecreaseBombExplosionTime,
            PUIncreaseBombExplosionTime,
            PUAutoPlacer,
            PUTemporarySwim,
            Water,
            FlameH,
            FlameV,
            FlameC
        }
    }
}
