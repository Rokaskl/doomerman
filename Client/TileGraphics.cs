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
    public class TileGraphics
    {
        protected Image tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png"));

        public Image GetTileGfx()
        {
            return tileGfx;
        }

        public void SetTileGfx(Image image)
        {
            tileGfx = image;
        }
    }
}
