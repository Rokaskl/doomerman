using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class MoveUpStrategy : IMoveStrategy
    {
        public void Move(Player player)
        {
            if (player.CanMove(ArenaCommandEnum.MoveUp)) player.MoveUp();
        }
    }
}
