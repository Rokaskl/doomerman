using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class GameObject : IGameObject
    {


        private Coordinates xy;
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

    }
}
