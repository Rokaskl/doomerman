using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OPP
{
    class Sprite : IComparable
    {
        public Image image { get; set; }
        public int layerIndex { get; set; }
        public Point pointPosition { get; set; }

        public Sprite() { }

        public Sprite(Image _image, int _layerIndex, Point _position)
        {
            image = _image;
            layerIndex = _layerIndex;
            pointPosition = _position;
        }

        public int CompareTo(object obj)
        {
            Sprite other = obj as Sprite;

            if (this.layerIndex == other.layerIndex)
                return 0;
            else if (this.layerIndex > other.layerIndex)
                return 1;

            return -1;

        }
    }
}
