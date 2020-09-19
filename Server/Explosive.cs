using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Explosive
    {
        public int BlastRadius;
        public Explosive(int blastRadius = 2)
        {
            this.BlastRadius = blastRadius;
        }
    }
}
