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
    public class AnimatedTile : Tile
    {
        private int frameCount = 1;
        private int currentFrame = 1;
        public bool shouldLoop = false;

        public override void UpdateGfx(TileTypeEnum tileType)
        {
            switch (tileType)
            {
                case TileTypeEnum.Bomb:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\bomb.png" + "_frame" + currentFrame)));
                    }
                    catch(Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;
                case TileTypeEnum.Crate:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\crate.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Player1:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player1.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Player2:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player2.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Player3:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player3.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Player4:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player4.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUIncreaseBombCount:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_increase.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUDecreaseBombCount:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_decrease.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUIncreaseBombRange:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_increase.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUDecreaseBombRange:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_decrease.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUTemporaryJump:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_jump.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.PUTemporaryShield:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_shield.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Wall:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.DestroyableWall:
                    try
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\destroyable_wall.png" + "_frame" + currentFrame)));
                    }
                    catch (Exception ex)
                    {
                        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;

                case TileTypeEnum.Empty:
                default:
                    tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
                    break;
            }
        }

        public void ChangeNextFrame()
        {
            if (shouldLoop)
            {
                if (currentFrame > frameCount)
                    currentFrame = 1;
                else
                    currentFrame++;
            }
            else
            {
                if (currentFrame < frameCount)
                {
                    currentFrame++;
                }
            }
        }
    }
}
