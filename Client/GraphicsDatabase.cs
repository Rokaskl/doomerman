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
    public static class GraphicsDatabase
    {
        public static Dictionary<TileTypeEnum, Image> images = new Dictionary<TileTypeEnum, Image>();

        public static void LoadImages()
        {
            images.Add(TileTypeEnum.Bomb, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\bomb.png")));
            //images.Add(TileTypeEnum.Crate, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\crate.png")));
            images.Add(TileTypeEnum.Empty, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\empty.png")));
            images.Add(TileTypeEnum.Player1, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player1.png")));
            images.Add(TileTypeEnum.Player2, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player2.png")));
            images.Add(TileTypeEnum.Player3, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player3.png")));
            images.Add(TileTypeEnum.Player4, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\player4.png")));
            //images.Add(TileTypeEnum.PUAutoPlacer, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_autoplaces.png")));
            images.Add(TileTypeEnum.PUBombKick, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombkick.png")));
            images.Add(TileTypeEnum.PUDecreaseBombCount, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_decrease.png")));
            //images.Add(TileTypeEnum.PUDecreaseBombExplosionTime, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_explosiontime_decrease.png")));
            images.Add(TileTypeEnum.PUDecreaseBombRange, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_decrease.png")));
            //images.Add(TileTypeEnum.PUDecreaseSpeed, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_speed_decrease.png")));
            //images.Add(TileTypeEnum.PUExtraLife, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_extralife.png")));
            images.Add(TileTypeEnum.PUIncreaseBombCount, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombcount_increase.png")));
            //images.Add(TileTypeEnum.PUIncreaseBombExplosionTime, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_explosiontime_increase.png")));
            images.Add(TileTypeEnum.PUIncreaseBombRange, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_bombrange_increase.png")));
            //images.Add(TileTypeEnum.PUIncreaseSpeed, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_speed_increase.png")));
            images.Add(TileTypeEnum.PUTemporaryJump, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_jump.png")));
            images.Add(TileTypeEnum.PUTemporaryShield, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_shield.png")));
            images.Add(TileTypeEnum.PUTemporarySwim, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\powerup_waterwalk.png")));
            images.Add(TileTypeEnum.Wall, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall.png")));
            images.Add(TileTypeEnum.DestroyableWall, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\wall_destructable.png")));
            images.Add(TileTypeEnum.Dead, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\dead.png")));
            images.Add(TileTypeEnum.FlameH, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameH.png")));
            images.Add(TileTypeEnum.FlameV, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameV.png")));
            images.Add(TileTypeEnum.FlameC, Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\flameC.png")));

        }

    }
}
