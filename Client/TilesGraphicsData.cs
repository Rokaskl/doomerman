using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPP.TileEnumerator;

namespace OPP
{
    public class TilesGraphicsData
    {
        List<TilesGraphicsDataObject> Data = new List<TilesGraphicsDataObject>();
        List<TileGraphics> TileGraphics = new List<TileGraphics>();
        public TilesGraphicsData()
        {
            GraphicsDatabase.LoadStaticImages();
            GraphicsDatabase.LoadAnimatedImages();
            FillTileGraphicsDataForStaticFields();
            ModifyAnimatedTilesGraphicsDataObject();
            CreateTileGraphicsList();
            ModifyTileGraphicsList();
        }

        public TilesGraphicsDataObject GetTilesGraphicsDataObject(int enumId) => this.Data.Find(i => i.EnumId == enumId);
        public TileGraphics GetTileGrapchicsObject(int id) => this.TileGraphics[id];

        public void FillTileGraphicsDataForStaticFields()
        {
            for (int i = 0; i < Enum.GetNames(typeof(TileEnumerator.TileTypeEnum)).Length; i++)
            {
                Data.Add(new TilesGraphicsDataObject(i,1));
            }
        }
        public void CreateTileGraphicsList()
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
        public void ModifyTileGraphicsList()
        {
            AnimatedTileGraphics chillWater = new AnimatedTileGraphics();
            foreach (Image chillWaterFrame in GraphicsDatabase.animatedImages[AnimationsEnum.ChillWater])
            {
                chillWater.Add(new StaticTileGraphics(chillWaterFrame));
            }
            this.TileGraphics[(int) TileTypeEnum.Water].Add(chillWater);


            AnimatedTileGraphics stormWater = new AnimatedTileGraphics();
            foreach (Image stormWaterFrame in GraphicsDatabase.animatedImages[AnimationsEnum.StormWater])
            {
                stormWater.Add(new StaticTileGraphics(stormWaterFrame));
            }

            this.TileGraphics[(int) TileTypeEnum.Water].Add(stormWater);

        }
        public void ModifyAnimatedTilesGraphicsDataObject()
        {
            //Water 4 Frames
           Data[Data.FindIndex(i => i.EnumId == (int) TileEnumerator.TileTypeEnum.Water)] = new TilesGraphicsDataObject((int) TileEnumerator.TileTypeEnum.Water, 4);
        }


    }
}
