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
    public class Tile
    {
        protected TileTypeEnum tileType = TileTypeEnum.Empty;
        protected TileGraphics tileGraphics;
        protected Point gfxPosition;

        public void SetTileType(TileTypeEnum type)
        {
            tileType = type;
            // UpdateGfx(tileType);
        }

        public void SetTilePosition(int xGrid, int yGrid)
        {
            // 16px tile width
            gfxPosition.X = (xGrid * 16) + 16; 
            gfxPosition.Y = (yGrid * 16) + 16;
        }

        public Point GetTileGfxPosition()
        {        
            return gfxPosition;
        }

        public void SetTileGfx(TileGraphics graphics)
        {
            tileGraphics = graphics;
        }

        public virtual void UpdateGfx(TileGraphics tileGraphics)
        {
            this.tileGraphics = tileGraphics;
         
        }

        public static bool isTileAnimated(TileTypeEnum tileType)
        {
            switch (tileType)
            {
                case TileTypeEnum.Water:
                    return true;

                default:
                    return false;
            }
        }
        public bool IsTileAnimated()
        {
            if (tileType == TileEnumerator.TileTypeEnum.Empty)
                return false;

            return this.tileGraphics.GetFramesCount() != 1;
        }
        public Image GetTileGfx()
        {
            return tileGraphics.GetTileGfx();
        }

        internal void UpdateGfx()
        {
            throw new NotImplementedException();
        }
    }
}
