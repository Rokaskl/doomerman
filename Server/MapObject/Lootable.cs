using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Lootable : GameObjectDecorator
    {

        public Lootable(IGameObject gameObject) : base(gameObject)
        {

        }
        public override List<string> GetTags()
        {
            List<string> newTags = base.GetTags();
            newTags.Add("Lootable");
            return newTags;
        }

        public override void PrintTags()
        {
            this.GetTags().ForEach(x => Console.WriteLine(x));
        }
        
        public override Coordinates GetCoordinates ()
        {
            return this.gameObject.GetCoordinates();
        }
    }
}