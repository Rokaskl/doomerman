using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Pickable : GameObjectDecorator
    {
       
        public Pickable(IGameObject gameObject) : base(gameObject){ }

        public override List<string> GetTags()
        {
            List<string> newTags = base.GetTags();
            newTags.Add("Pickable");
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
