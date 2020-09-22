using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public abstract class GameObjectDecorator : GameObject
    {
        protected GameObject gameObject;
        public GameObjectDecorator(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
