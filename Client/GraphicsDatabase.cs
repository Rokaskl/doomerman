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
        public static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static Dictionary<TileTypeEnum, Image> staticImages = new Dictionary<TileTypeEnum, Image>();

        public static Dictionary<AnimationsEnum, List<Image>> animatedImages = new Dictionary<AnimationsEnum, List<Image>>();

        public static void LoadStaticImages()
        {
            staticImages.Add(TileTypeEnum.Bomb, Image.FromFile(Path.Combine(ProjectPath, "Resources\\bomb.png")));
            staticImages.Add(TileTypeEnum.Crate, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.Empty, Image.FromFile(Path.Combine(ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.Player1, Image.FromFile(Path.Combine(ProjectPath, "Resources\\player1.png")));
            staticImages.Add(TileTypeEnum.Player2, Image.FromFile(Path.Combine(ProjectPath, "Resources\\player2.png")));
            staticImages.Add(TileTypeEnum.Player3, Image.FromFile(Path.Combine( ProjectPath, "Resources\\player3.png")));
            staticImages.Add(TileTypeEnum.Player4, Image.FromFile(Path.Combine( ProjectPath, "Resources\\player4.png")));
            staticImages.Add(TileTypeEnum.PUAutoPlacer, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUBombKick, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_bombkick.png")));
            staticImages.Add(TileTypeEnum.PUDecreaseBombCount, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_bombcount_decrease.png")));
            staticImages.Add(TileTypeEnum.PUDecreaseBombExplosionTime, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUDecreaseBombRange, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_bombrange_decrease.png")));
            staticImages.Add(TileTypeEnum.PUDecreaseSpeed, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUExtraLife, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUIncreaseBombCount, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_bombcount_increase.png")));
            staticImages.Add(TileTypeEnum.PUIncreaseBombExplosionTime, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUIncreaseBombRange, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_bombrange_increase.png")));
            staticImages.Add(TileTypeEnum.PUIncreaseSpeed, Image.FromFile(Path.Combine( ProjectPath, "Resources\\empty.png")));
            staticImages.Add(TileTypeEnum.PUTemporaryJump, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_jump.png")));
            staticImages.Add(TileTypeEnum.PUTemporaryShield, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_shield.png")));
            staticImages.Add(TileTypeEnum.PUTemporarySwim, Image.FromFile(Path.Combine( ProjectPath, "Resources\\powerup_waterwalk.png")));
            staticImages.Add(TileTypeEnum.Wall, Image.FromFile(Path.Combine( ProjectPath, "Resources\\wall.png")));
            staticImages.Add(TileTypeEnum.DestroyableWall, Image.FromFile(Path.Combine( ProjectPath, "Resources\\wall_destructable.png")));
            staticImages.Add(TileTypeEnum.Dead, Image.FromFile(Path.Combine( ProjectPath, "Resources\\dead.png")));
            staticImages.Add(TileTypeEnum.FlameH, Image.FromFile(Path.Combine( ProjectPath, "Resources\\flameH.png")));
            staticImages.Add(TileTypeEnum.FlameV, Image.FromFile(Path.Combine( ProjectPath, "Resources\\flameV.png")));
            staticImages.Add(TileTypeEnum.FlameC, Image.FromFile(Path.Combine( ProjectPath, "Resources\\flameC.png")));
            staticImages.Add(TileTypeEnum.Water, Image.FromFile(Path.Combine( ProjectPath, "Resources\\water_frame0.png")));
        }
        public static void LoadAnimatedImages()
        {
            animatedImages.Add(AnimationsEnum.ChillWater, new List<Image> { Image.FromFile(Path.Combine( ProjectPath, "Resources\\water_frame0.png")), Image.FromFile(Path.Combine( ProjectPath, "Resources\\water_frame1.png")) }) ;
            animatedImages.Add(AnimationsEnum.StormWater, new List<Image> { Image.FromFile(Path.Combine( ProjectPath, "Resources\\waterStorm_frame0.png")), Image.FromFile(Path.Combine( ProjectPath, "Resources\\waterStorm_frame1.png")) });

        }


    }
}
