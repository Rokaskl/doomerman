using System;
using System.Collections.Generic;
using System.Text;
using Server.Iterator;

namespace Server
{
    public abstract class Arena
    {
        public List<IGameObject> flames = new List<IGameObject>();
        public List<IGameObject> gameObjects = new List<IGameObject>();
        public IAggregate<Player> Players;
        public int[,] walls;
        public Grid grid;
        public bool UpdateRequired;

        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(IGameObject gameObject, int x, int y)
        {
            gameObjects.RemoveAll(z => z is null); // kartais atsiranda null, atrodo niekur neprilyginu jokio gameobject i null
            //cj labai expensive dalykas, kiekvienam updatui. padekit sugalvot geresni
            gameObjects.RemoveAll(z => z.GetType() == gameObject.GetType() && z.GetCords().X == x && z.GetCords().Y == y);
        }
        public void RemoveGameObjectAt(int x, int y)
        {
            gameObjects.RemoveAll(z => z is null); // kartais atsiranda null, atrodo niekur neprilyginu jokio gameobject i null
            //cj labai expensive dalykas, kiekvienam updatui. padekit sugalvot geresni
            gameObjects.RemoveAll(z => z.GetTags().Contains("Pickable") && z.GetCords().X == x && z.GetCords().Y == y);
        }
    }
}
