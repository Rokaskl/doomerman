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
    class Tile : IReset
    {
        private Image tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png"));
        private TileTypeEnum tileType = TileTypeEnum.Empty;

        private Point gfxPosition;

        public void UpdateGfx()
        {
            switch (tileType)
            {
                case TileTypeEnum.Bomb:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\bomb.png"));
                    break;
                case TileTypeEnum.Crate:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\crate.png"));
                    break;
       
                case TileTypeEnum.Player1:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player1.png"));
                    break;

                case TileTypeEnum.Player2:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player2.png"));
                    break;

                case TileTypeEnum.Player3:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player3.png"));
                    break;

                case TileTypeEnum.Player4:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player4.png"));
                    break;

                case TileTypeEnum.PUIncreaseBombCount:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_increase.png"));
                    break;

                case TileTypeEnum.PUDecreaseBombCount:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_decrease.png"));
                    break;

                case TileTypeEnum.PUIncreaseBombRange:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_increase.png"));
                    break;

                case TileTypeEnum.PUDecreaseBombRange:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_decrease.png"));
                    break;

                case TileTypeEnum.PUTemporaryJump:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_jump.png"));
                    break;

                case TileTypeEnum.PUTemporaryShield:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_shield.png"));
                    break;

                case TileTypeEnum.Wall:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall.png"));
                    break;

                case TileTypeEnum.Empty:
                default:
                    tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png"));
                    break;
            }
        }

        public void SetTileType(TileTypeEnum type)
        {
            tileType = type;
            UpdateGfx();
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

            //throw new Exception("Cannot get the Tile's Graphics position, position is not set. Consider using SetTilePosition() function");
        }

        public Image GetTileGfx()
        {
            return tileGfx;
        }

        public void Reset()
        {
            tileGfx = Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png"));
            tileType = TileTypeEnum.Empty;
        }
    }
}
