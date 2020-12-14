using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class AnimatedTileGraphics : TileGraphics
    {
        private List<TileGraphics> frames = new List<TileGraphics>();
        public AnimatedTileGraphics(Image tileGfx) : base(tileGfx) //Initial frame
        {

        }
        public AnimatedTileGraphics() : base()
        {

        }
        public override void Add(TileGraphics tileGraphics) => this.frames.Add(tileGraphics);

        public override void Remove(TileGraphics tileGraphics) => this.frames.Remove(tileGraphics);
        public override List<Image> GetFrames()
        {
            List<Image> frameStack = new List<Image>
            {
                this.tileGfx
            };

            foreach (TileGraphics tileGraphics in this.frames)
            {
                frameStack = frameStack.Concat(tileGraphics.GetFrames()).ToList();
            }
            return frameStack;
        }
    }
}
