using System;
using System.Collections.Generic;
using System.Text;
using Server.Prototype;

namespace Server
{
    public class Coordinates : CordPrototype
    {
        public int X;
        public int Y;

        public Coordinates(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public override CordPrototype Clone()
        {
            return this.MemberwiseClone() as CordPrototype;
        }
        public override string ToString()
        {
            return "|x: " + this.X.ToString() + " | y: " + this.Y.ToString() + " | ";
        }
    }
}
