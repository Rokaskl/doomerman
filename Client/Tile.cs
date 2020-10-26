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
        protected TileGraphics tileGraphics = new TileGraphics();
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

        public virtual void UpdateGfx(TileTypeEnum tileType)
        {
            switch (tileType)
            {
                case TileTypeEnum.Bomb:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\bomb.png")));
                    break;
                case TileTypeEnum.Crate:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\crate.png")));
                    break;

                case TileTypeEnum.Player1:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player1.png")));
                    break;

                case TileTypeEnum.Player2:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player2.png")));
                    break;

                case TileTypeEnum.Player3:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player3.png")));
                    break;

                case TileTypeEnum.Player4:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player4.png")));
                    break;

                case TileTypeEnum.PUIncreaseBombCount:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_increase.png")));
                    break;

                case TileTypeEnum.PUDecreaseBombCount:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_decrease.png")));
                    break;

                case TileTypeEnum.PUIncreaseBombRange:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_increase.png")));
                    break;

                case TileTypeEnum.PUDecreaseBombRange:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_decrease.png")));
                    break;

                case TileTypeEnum.PUTemporaryJump:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_jump.png")));
                    break;

                case TileTypeEnum.PUTemporaryShield:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_shield.png")));
                    break;

                case TileTypeEnum.Wall:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall.png")));
                    break;

                case TileTypeEnum.DestroyableWall:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall_destructable.png")));
                    break;

                case TileTypeEnum.Empty:
                default:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
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
