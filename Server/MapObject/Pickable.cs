using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Pickable : GameObjectDecorator
    {
        protected Player player;
        public Pickable(GameObject gameObject, GameArena arena, Player player) : base(gameObject)
        {
            this.player = player;
        }

        public void  PickUp()
        {
            player.AddPowerUp(this);
        }
      

    }
}
