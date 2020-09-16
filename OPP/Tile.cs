using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPP.TileEnumerator;

namespace OPP
{
    class Tile : IDie
    {
        public Image tileGfx = Image.FromFile("/Resources/empty.png");
        public TileTypeEnum tileType = TileTypeEnum.Empty;

        public void Die()
        {
            tileGfx = Image.FromFile("/Resources/empty.png");
            
        }

        public void UpdateGfx()
        {
            switch (tileType)
            {
                case TileTypeEnum.Bomb:
                    tileGfx = Image.FromFile("/Resources/bomb.png");
                    break;
                case TileTypeEnum.Crate:
                    tileGfx = Image.FromFile("/Resources/crate.png");
                    break;
                case TileTypeEnum.Player:
                    // by ID
                    /*switch (Player.GetID())
                    {
                        case 0:
                            tileGfx = Image.FromFile("/Resources/player1.png");
                            break;
                        case 1:
                            tileGfx = Image.FromFile("/Resources/player2.png");
                            break;
                        case 2:
                            tileGfx = Image.FromFile("/Resources/player3.png");
                            break;
                        case 3:
                            tileGfx = Image.FromFile("/Resources/player4.png");
                            break;
                    }*/
                    
                    break;
                case TileTypeEnum.PowerUp:
                    // TODO
                    tileGfx = Image.FromFile("/Resources/empty.png");
                    break;
                case TileTypeEnum.Wall:
                    tileGfx = Image.FromFile("/Resources/wall.png");
                    break;
                default:
                    tileGfx = Image.FromFile("/Resources/empty.png");
                    break;
            }

        }
    }
}
