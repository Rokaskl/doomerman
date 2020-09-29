using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class GameObject : IGameObject
    {


        private Coordinates xy;
        private Pickable loot = null;
        public GameObject(Coordinates xy)
        {
            this.xy  = xy;
        }

        public List<string> GetTags()
        {
            return new List<string>();
        }

        public void PrintTags()
        {
            this.GetTags().ForEach(x => Console.WriteLine(x));
        }
        public Coordinates GetCoordinates()
        {
            return this.xy;
        }
        public void AddLoot(Pickable gameObject)
        {
            this.loot = gameObject;
        }
        public Pickable GetLoot()
        {
            return this.loot;
        }
    }
}
