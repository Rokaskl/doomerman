using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace OPP
{
    class DrawQueue
    {
        Graphics imageGfx;
        Graphics screenGfx;
        Bitmap bitmap;
        PictureBox drawingArea;

        Dictionary<int, Entity> Entities = new Dictionary<int, Entity>();
        public readonly object _spriteLock = new object();

        public bool draw = true;

        public int count = 0; 
        
        public DrawQueue(Graphics _screenGfx, PictureBox _drawingArea)
        {
            screenGfx = _screenGfx;
            drawingArea = _drawingArea;
            bitmap = new Bitmap(512, 512);
            imageGfx = Graphics.FromImage(bitmap);
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity.ID, entity);

            Entities.OrderBy(key => key.Value.sprite.layerIndex);      

            count++;
        }

        public Entity GetEntity(int ID)
        {
            return Entities[ID];
        }

        public bool ContainsKey(int ID)
        {
            return Entities.ContainsKey(ID);
        }

        public void Draw()
        {
            while (draw)
            {
                lock (_spriteLock)
                {
                    // draws background to image first
                    imageGfx.DrawImage(drawingArea.Image, 0, 0);

                    foreach (var entity in Entities)
                    {                    
                        imageGfx.DrawImage(entity.Value.sprite.image, entity.Value.sprite.pointPosition.X, entity.Value.sprite.pointPosition.Y);
                    }
                    screenGfx.DrawImage(bitmap, 0, 0);
                }
            }
        }
        
    }
}
