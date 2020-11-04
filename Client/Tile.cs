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
            UpdateGfx(tileType);
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

        public virtual void UpdateGfx(TileTypeEnum tileType)
        {
            switch (tileType)
            {
                case TileTypeEnum.Bomb:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Bomb]);
                    break;
                case TileTypeEnum.Crate:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Crate]);
                    break;

                case TileTypeEnum.Player1:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Player1]);
                    break;

                case TileTypeEnum.Player2:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Player2]);
                    break;

                case TileTypeEnum.Player3:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Player3]);
                    break;

                case TileTypeEnum.Player4:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Player4]);
                    break;

                case TileTypeEnum.PUIncreaseBombCount:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUIncreaseBombCount]);
                    break;

                case TileTypeEnum.PUDecreaseBombCount:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUDecreaseBombCount]);
                    break;

                case TileTypeEnum.PUIncreaseBombRange:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUIncreaseBombRange]);
                    break;

                case TileTypeEnum.PUDecreaseBombRange:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUDecreaseBombRange]);
                    break;

                case TileTypeEnum.PUTemporaryJump:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUTemporaryJump]);
                    break;

                case TileTypeEnum.PUTemporaryShield:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUTemporaryShield]);
                    break;

                case TileTypeEnum.Wall:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Wall]);
                    break;

                case TileTypeEnum.DestroyableWall:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.DestroyableWall]);
                    break;

                case TileTypeEnum.PUBombKick:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUBombKick]);
                    break;

                case TileTypeEnum.PUTemporarySwim:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.PUTemporarySwim]);
                    break;
                case TileTypeEnum.Dead:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Dead]);
                    break;

                case TileTypeEnum.Empty:
                default:
                    tileGraphics.SetTileGfx(GraphicsDatabase.images[TileTypeEnum.Empty]);
                    break;
            }
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

        public Image GetTileGfx()
        {
            return tileGraphics.GetTileGfx();
        }
    }
}
