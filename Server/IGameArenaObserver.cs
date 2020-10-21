using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    interface IGameArenaObserver
    {
        public void Notify();
        public void AddPlayer(Player player);
    }
}
