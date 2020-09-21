using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class TileEnumerator
    {
        public enum TileTypeEnum {
            Player1,
            Player2,
            Player3,
            Player4,
            Bomb,
            Wall,
            Crate,
            PUIncreaseBombRange,
            PUDecreaseBombRange,
            PUIncreaseBombCount,
            PUDecreaseBombCount,
            PUTemporaryShield,
            PUTemporaryJump,
            Empty
        }
    }
}
