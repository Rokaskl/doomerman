using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Pickable : GameObjectDecorator
    {
       
        public Pickable(GameObject gameObject) : base(gameObject)
        {
           
        }

        public void  PickUp(Player player)
        {
            player.AddPowerUp(this);
        }

    }
}
