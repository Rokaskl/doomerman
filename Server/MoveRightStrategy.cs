using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class MoveRightStrategy : IMoveStrategy
    {
        public void Move(Player player)
        {
            if (player.CanMove(CommandEnum.MoveRight)) player.MoveRight();
        }
    }
}
