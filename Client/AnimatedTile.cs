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
        private int currentFrame = 0;
        public bool shouldLoop = false;

        public AnimatedTile(int frameCount,bool shouldLoop, int startFromFrame = 0)
        {
            this.frameCount = frameCount;
            this.shouldLoop = shouldLoop;
            this.currentFrame = startFromFrame;
        }
        public override void UpdateGfx(TileGraphics tileGraphics)
        {
            this.tileGraphics = tileGraphics;



            //switch (tileType)
            //{
            //    case TileTypeEnum.Bomb:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\bomb" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch(Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;
            //    case TileTypeEnum.Crate:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\crate" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Player1:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player1" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Player2:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player2" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Player3:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player3" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Player4:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player4" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUIncreaseBombCount:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_increase" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUDecreaseBombCount:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_decrease" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUIncreaseBombRange:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_increase" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUDecreaseBombRange:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_decrease" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUTemporaryJump:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_jump" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUTemporaryShield:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_shield" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Wall:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.DestroyableWall:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\destroyable_wall" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.PUBombKick:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombkick" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Water:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\water" + "_frame" + currentFrame + ".png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;
            //    case TileTypeEnum.Dead:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\dead.png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;
            //    case TileTypeEnum.FlameH:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameH.png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;
            //    case TileTypeEnum.FlameV:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameV.png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;
            //    case TileTypeEnum.FlameC:
            //        try
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameC.png")));
            //        }
            //        catch (Exception ex)
            //        {
            //            tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //            Console.WriteLine(ex.Message);
            //            break;
            //        }
            //        break;

            //    case TileTypeEnum.Empty:
            //    default:
            //        tileGraphics.SetTileGfx(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            //        break;
            //}
        }

        public void ChangeNextFrame()
        {
            if (shouldLoop)
            {
                if (currentFrame+1 > frameCount)
                    currentFrame = 1;
                else
                    currentFrame++;
            }
            else
            {
                if (currentFrame+1 < frameCount)
                {
                    currentFrame++;
                }
            }
        }
    }
}
