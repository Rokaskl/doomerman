using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public interface IMoveStrategy
    {
        void Move(Player player);
    }
}
