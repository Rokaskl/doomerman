using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPP.TileEnumerator;

namespace OPP
{
    public abstract class TileGraphics
    {

        protected Image currentFrameImage;

        public TileGraphics(Image tileGfx)
        {
            this.currentFrameImage = tileGfx;
        }

        public TileGraphics()
        {
            this.currentFrameImage = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")); // Empty tile
        }
        public Image GetTileGfx(int currentFrame)
        {
           return this.GetFrames()[currentFrame];
        }
        public Image GetTileGfx()
        {
            return this.currentFrameImage;
        }
        public void SetTileGfx(Image image) => this.currentFrameImage = image;
        public abstract void Add(TileGraphics tileGraphics);
        public abstract void Remove(TileGraphics tileGraphics);
        public abstract List<Image> GetFrames();
        public int GetFramesCount()
        {
            return this.GetFrames().Count;
        }

    }
}
