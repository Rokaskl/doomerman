using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class TilesGraphicsDataObject
    {
        public int EnumId = 0;


        public int FrameCount = 1;
        public TilesGraphicsDataObject(int enumId, int frameCount)
        {
            this.EnumId = enumId;
            this.FrameCount = frameCount;
        }
        

    }
}
