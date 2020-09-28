using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Explosive : GameObjectDecorator
    {
        public int BlastRadius { get; set; } = 2;
        public Explosive(GameObject gameObject) : base(gameObject)
        {
            
        }
        
    }
}
