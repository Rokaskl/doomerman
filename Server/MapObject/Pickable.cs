using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Pickable : GameObjectDecorator
    {
        public TileEnumerator.TileTypeEnum type = TileEnumerator.TileTypeEnum.Empty;
        public Pickable(IGameObject gameObject) : base(gameObject){ }
        public Pickable():base (new GameObject(new Coordinates(0,0)))
        {

        }

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
        public override Coordinates GetCords()
        {
            return base.GetCords();
        }

    }
}
