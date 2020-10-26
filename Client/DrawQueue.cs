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
    class DrawQueue
    {
        Graphics imageGfx;
        Graphics screenGfx;
        Bitmap bitmap;
        PictureBox drawingArea;

        //Dictionary<Point, List<Tile>> Grid = new Dictionary<Point, List<Tile>>();
        //Grid grid;
        public readonly object _spriteLock = new object();

        public bool draw = true;

        public int count = 0;

        public DrawQueue(Graphics _screenGfx, PictureBox _drawingArea)
        {
            screenGfx = _screenGfx;
            drawingArea = _drawingArea;
            bitmap = new Bitmap(480, 480);
            imageGfx = Graphics.FromImage(bitmap);
            screenGfx.InterpolationMode = InterpolationMode.NearestNeighbor;

            ClientManager.Instance.SetGrid( new Grid());

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

        public void Draw()
        {
            while (draw)
            {
                lock (_spriteLock)
                {
                    // Update grid

                    // draws background to image first
                    if (drawingArea.InvokeRequired)
                    {
                        drawingArea.Invoke(new MethodInvoker(delegate { imageGfx.DrawImage(Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/Background.png"), 0, 0); }));
                    }
                    else
                    {
                        imageGfx.DrawImage(drawingArea.Image, 0, 0);
                    }

                    for(int x = 0; x < 13; x++)
                    {
                        for(int y = 0; y < 13; y++)
                        {
                            foreach(var tile in ClientManager.Instance.GetGrid().GetTile(x, y))
                            {
                                imageGfx.DrawImage(tile.GetTileGfx(), tile.GetTileGfxPosition());
                            }
                        }
                    }
     
                    screenGfx.DrawImage(bitmap, 0, 0, 960, 960);
                }
            }
        }

    }
}
