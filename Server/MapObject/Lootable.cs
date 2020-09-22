using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Lootable : GameObjectDecorator
    {
        private Pickable loot;
        private GameArena arena;
        public Lootable(GameObject gameObject, Pickable loot, GameArena arena) : base(gameObject)
        {
            this.arena = arena;
            this.loot = loot;
        }
        public void DropLoot()
        {
            this.arena.AddGameObject(loot);
        }

    }
}