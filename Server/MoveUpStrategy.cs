using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class MoveUpStrategy : IMoveStrategy
    {
        public void Move(Player player, int[,] walls)
        {
            if (player.CanMove(ArenaCommandEnum.MoveUp, walls)) player.MoveUp();
        }
    }
}
