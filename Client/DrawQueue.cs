using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting.Messaging;

namespace OPP
{
    public class DrawQueue
    {
        static Graphics imageGfx;
        static Graphics screenGfx;
        static Bitmap bitmap;
        static PictureBox drawingArea;
        Timer timer;

        public DrawQueue(Graphics _screenGfx, PictureBox _drawingArea)
        {
            screenGfx = _screenGfx;
            drawingArea = _drawingArea;
            bitmap = new Bitmap(480, 480);
            imageGfx = Graphics.FromImage(bitmap);
            screenGfx.InterpolationMode = InterpolationMode.NearestNeighbor;

            ClientManager.Instance.SetGrid( new Grid());
            InitTimer();
        }

        /// <summary>
        /// Adds a list of tiles to a specified position
        /// </summary>
        /// <param name="pos">Graphics position</param>
        /// <param name="tile">List of tiles</param>
        public void AddTiles(Point pos, List<Tile> tile)
        {
            ClientManager.Instance.GetGrid().SetTile(pos.X, pos.Y, tile);
        }

        /// <summary>
        /// Returns a list of tiles based on the position
        /// </summary>
        /// <param name="pos">Tile position on the grid</param>
        /// <returns>List of tiles</returns>
        public List<Tile> GetTiles(Point pos)
        {
            return ClientManager.Instance.GetGrid().GetTile(pos.X, pos.Y);
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(updateAnimatedTiles);
            timer.Interval = 500; // in miliseconds
            timer.Start();
        }

        private void updateAnimatedTiles(object sender, EventArgs e)
        {
            bool updateRequired = false;
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    foreach (Tile tile in ClientManager.Instance.GetGrid().GetTile(x, y))
                    {
                        if (tile.IsTileAnimated())
                        {
                            imageGfx.DrawImage(tile.GetTileGfx(), tile.GetTileGfxPosition());
                            updateRequired = true;
                        }
                    }
                }
            }
            if (updateRequired)
            {
                //drawingArea.InvokeRequired = false;
                Draw();
            }
        }
        public static void Draw()
        {

            // Update grid

            // draws background to image first
            if (drawingArea.InvokeRequired)
            {
                drawingArea.Invoke(new MethodInvoker(delegate
                {
                    imageGfx.DrawImage(Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/Background.png"), 0, 0);
                }));
            }
            else
            {
                imageGfx.DrawImage(Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/Background.png"), 0, 0);
            }

            for(int x = 0; x < 13; x++)
            {
                for(int y = 0; y < 13; y++)
                {
                    foreach(Tile tile in ClientManager.Instance.GetGrid().GetTile(x, y))
                    {
                        imageGfx.DrawImage(tile.GetTileGfx(), tile.GetTileGfxPosition());
                    }
                }
            }
            
            screenGfx.DrawImage(bitmap, 0, 0, 960, 960);

        }

    }
}
