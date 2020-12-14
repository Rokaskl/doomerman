using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public class AnimatedTileGraphics : TileGraphics
    {
        private int currentFrame = 1;

        private Timer timer;
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            List<Image> frames = GetFrames();
            this.currentFrameImage = frames[currentFrame];
            if (currentFrame+1 < frames.Count)
            {
                currentFrame++;
            }
            else
            {
                currentFrame = 1;
            }

        }
        private List<TileGraphics> frames = new List<TileGraphics>();
        public AnimatedTileGraphics(Image tileGfx) : base(tileGfx) //Initial frame
        {
            this.InitTimer();

        }
        public AnimatedTileGraphics() : base()
        {
            this.InitTimer();

        }
        public override void Add(TileGraphics tileGraphics) => this.frames.Add(tileGraphics);

        public override void Remove(TileGraphics tileGraphics) => this.frames.Remove(tileGraphics);
        public override List<Image> GetFrames()
        {
            List<Image> frameStack = new List<Image>
            {
                this.currentFrameImage
            };

            foreach (TileGraphics tileGraphics in this.frames)
            {
                frameStack = frameStack.Concat(tileGraphics.GetFrames()).ToList();
            }
            return frameStack;
        }
    }
}
