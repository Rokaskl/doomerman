using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class StaticTileGraphics : TileGraphics
    {
        public StaticTileGraphics(Image tileGfx): base(tileGfx){}
        public StaticTileGraphics() : base(){ }
        public override void Add(TileGraphics tileGraphics) => throw new InvalidOperationException("Cannot add tileGraphics to a StaticTileGraphics");

        public override void Remove(TileGraphics tileGraphics) => throw new InvalidOperationException("Cannot remove tileGraphics from a StaticTileGraphics");

        public override List<Image> GetFrames()
        {
            List<Image> singleFrameList = new List<Image>
            {
                this.currentFrameImage
            };
            return singleFrameList;
        }
    }
}
