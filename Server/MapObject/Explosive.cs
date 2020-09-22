using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Explosive : GameObjectDecorator
    {
        public int BlastRadius { get; set; }
        public Explosive(GameObject gameObject) : base(gameObject)
        {
            
        }
        
    }
}
