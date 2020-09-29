using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Explosive : GameObjectDecorator
    {
        public Explosive(IGameObject gameObject) : base(gameObject)
        {

        }

        public override List<string> GetTags()
        {
            List<string> newTags = base.GetTags();
            newTags.Add("Explosive");
            return newTags;
        }

        public override void PrintTags()
        {
            this.GetTags().ForEach(x => Console.WriteLine(x));
        }
        public override Coordinates GetCoordinates()
        {
            return base.GetCoordinates();
        }
    }
}
