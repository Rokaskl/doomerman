using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPP.PowerUpEnumerator;
using static OPP.TileEnumerator;

namespace OPP
{
    class Tile : IDie
    {
        private Image tileGfx = Image.FromFile("/Resources/empty.png");
        private TileTypeEnum tileType = TileTypeEnum.Empty;
        private PowerUpType powerUpType = PowerUpType.None;

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

                    switch (ClientManager.Instance.GetPlayerID())
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
                    }

                    break;
                case TileTypeEnum.PowerUp:
                    // TODO
                    switch (powerUpType)
                    {
                        case PowerUpType.IncreaseBombCount:
                            tileGfx = Image.FromFile("/Resources/powerup_bombcount_increase.png");
                            break;

                        case PowerUpType.DecreaseBombCount:
                            tileGfx = Image.FromFile("/Resources/powerup_bombcount_decrease.png");
                            break;

                        case PowerUpType.IncreaseBombRange:
                            tileGfx = Image.FromFile("/Resources/powerup_bombrange_increase.png");
                            break;

                        case PowerUpType.DecreaseBombRange:
                            tileGfx = Image.FromFile("/Resources/powerup_bombrange_decrease.png");
                            break;

                        case PowerUpType.TemporaryJump:
                            tileGfx = Image.FromFile("/Resources/powerup_jump.png");
                            break;

                        case PowerUpType.TemporaryShield:
                            tileGfx = Image.FromFile("/Resources/powerup_shield.png");
                            break;

                        default:
                            tileGfx = Image.FromFile("/Resources/empty.png");
                            break;
                    }
                    break;

                case TileTypeEnum.Wall:
                    tileGfx = Image.FromFile("/Resources/wall.png");
                    break;

                default:
                    tileGfx = Image.FromFile("/Resources/empty.png");
                    break;
            }
        }

        public void SetTileType(TileTypeEnum type)
        {
            if (type == TileTypeEnum.PowerUp)
                powerUpType = PowerUpType.None;

            tileType = type;

        }

        public void SetPowerUpType(PowerUpType type)
        {
            tileType = TileTypeEnum.PowerUp;
            powerUpType = type;
        }

        public Image GetTileGfx()
        {
            return tileGfx;
        }
    }
}
