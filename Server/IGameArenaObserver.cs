using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    interface IGameArenaObserver
    {
        public void AddPlayer(Player player);
        public void Notify();
    }
}
