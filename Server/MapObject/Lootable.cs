using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Lootable : GameObjectDecorator
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
        
        public override Coordinates GetCords ()
        {
            return this.gameObject.GetCords();
        }
    


    }
}