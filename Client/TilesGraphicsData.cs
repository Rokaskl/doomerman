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
    public static class TilesGraphicsData
    {
        static List<TilesGraphicsDataObject> Data = new List<TilesGraphicsDataObject>();
        static List<TileGraphics> TileGraphics = new List<TileGraphics>();

        public static void LoadData()
        {
            FillTileGraphicsDataForStaticFields();
            ModifyAnimatedTilesGraphicsDataObject();
            CreateTileGraphicsList();
            ModifyTileGraphicsList();
        }
        public static TilesGraphicsDataObject GetTilesGraphicsDataObject(int enumId) => Data.Find(i => i.EnumId == enumId);
        public static TileGraphics GetTileGrapchicsObject(int id) => TileGraphics[id];

        public static void FillTileGraphicsDataForStaticFields()
        {
            for (int i = 0; i < Enum.GetNames(typeof(TileEnumerator.TileTypeEnum)).Length; i++)
            {
                Data.Add(new TilesGraphicsDataObject(i,1));
            }
        }

        public static void ModifyAnimatedTilesGraphicsDataObject()
        {
            //Water 4 Frames
            Data[Data.FindIndex(i => i.EnumId == (int) TileEnumerator.TileTypeEnum.Water)] = new TilesGraphicsDataObject((int) TileEnumerator.TileTypeEnum.Water, 4);
        }
        public static void CreateTileGraphicsList()
        {
            for (int i =0; i < Enum.GetNames(typeof(TileEnumerator.TileTypeEnum)).Length; i++)
            {
                if (GetTilesGraphicsDataObject(i).FrameCount <= 1)
                {
                    TileGraphics.Add(new StaticTileGraphics(GraphicsDatabase.staticImages[(TileTypeEnum)i]));
                }
                else
                {
                    TileGraphics.Add(new AnimatedTileGraphics());

                }
            }
        }
        public static void ModifyTileGraphicsList()
        {
            AnimatedTileGraphics chillWater = new AnimatedTileGraphics();
            foreach (Image chillWaterFrame in GraphicsDatabase.animatedImages[AnimationsEnum.ChillWater])
            {
                chillWater.Add(new StaticTileGraphics(chillWaterFrame));
            }
            TileGraphics[(int) TileTypeEnum.Water].Add(chillWater);


            AnimatedTileGraphics stormWater = new AnimatedTileGraphics();
            foreach (Image stormWaterFrame in GraphicsDatabase.animatedImages[AnimationsEnum.StormWater])
            {
                stormWater.Add(new StaticTileGraphics(stormWaterFrame));
            }

            TileGraphics[(int) TileTypeEnum.Water].Add(stormWater);

        }
 


    }
}
