using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class MoveLeftStrategy : IMoveStrategy
    {
        public void Move(Player player)
        {
            if (player.CanMove(CommandEnum.MoveLeft)) player.MoveLeft();
        }
    }
}
