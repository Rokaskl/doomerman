using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class Entity
    {
        public int ID { get; set; }
        public Sprite sprite { get; set; }
        public Point point { get; set; }

        public Entity() { }

        public Entity(Sprite _sprite, Point _point)
        {
            ID = Form1.IDcounter++;
            sprite = _sprite;
            point = _point;
        }
    }
}
