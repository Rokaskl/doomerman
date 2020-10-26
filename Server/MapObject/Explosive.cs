using System;
using System.Collections.Generic;
using System.Text;
using Server.constants;

namespace Server
{
    public class Explosive : GameObjectDecorator
    {
        public int Radius;
        public int Time;
        public bool Droped;
        public Explosive(): base(new GameObject(new Coordinates(0, 0)))
        {
            Radius = Constants.StartBombRadius;
            Time = Constants.StartBombTimeMs;
            Droped = true;
        } 
        public Explosive(int x, int y) : base(new GameObject(new Coordinates(x,y))) { }
        public Explosive(IGameObject obj) : base(obj) { }
        public void IncRadius()
        {
            if(Radius<Constants.MaxBombRadius)
            {
                Radius++;
            }
        }
        public void DecRadius()
        {
            if (Radius > 1)
            {
                Radius--;
            }
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
        public override Coordinates GetCords()
        {
            return base.GetCords();
        }
        public override void SetCords(Coordinates xy)
        {
            base.SetCords(xy);
        }
    }
}
