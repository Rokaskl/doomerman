using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Destroyable : GameObjectDecorator
    {
        private GameArena arena;
        public Destroyable(GameObject gameObject, GameArena arena): base(gameObject)
        {
            this.arena = arena;
        }

        public void Destroy()
        {
            this.arena.RemoveGameObject(this);
        }

    }
}
