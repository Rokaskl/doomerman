using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject
{
    public class Flame : GameObject
    {
        public int[,] flames;
        public Flame(Coordinates xy) : base(xy)
        {
            flames = new int[13, 13];
        }
    }
}
