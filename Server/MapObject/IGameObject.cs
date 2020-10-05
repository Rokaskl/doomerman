using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public interface IGameObject
    {
        List<string> GetTags();
        void PrintTags();
        Coordinates GetCords();
        void AddLoot(Pickable gameObject);
        Pickable GetLoot();
    }
}
