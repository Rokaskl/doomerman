using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public abstract class GameObjectDecorator : IGameObject
    {
        protected IGameObject gameObject;
        public GameObjectDecorator(IGameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual List<string> GetTags() 
        {
            return this.gameObject.GetTags();
        }
        public virtual void PrintTags()
        {
            this.gameObject.PrintTags();
        }
        public virtual Coordinates GetCords()
        {
            return this.gameObject.GetCords();
        }
        public virtual void AddLoot(Pickable gameObject)
        {
             this.gameObject.AddLoot(gameObject);
        }
        public virtual Pickable GetLoot()
        {
            return this.gameObject.GetLoot();
        }
    }

}
