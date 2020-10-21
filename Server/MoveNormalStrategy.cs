using Server.CommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class MoveNormalStrategy : IMoveStrategy
    {
        public void MoveDown(Player player, List<int>[,] walls)
        {
            if (player.CanMove(ArenaCommandEnum.MoveDown, walls)) player.MoveDown();
        }

        public void MoveLeft(Player player, List<int>[,] walls)
        {
            if (player.CanMove(ArenaCommandEnum.MoveLeft, walls)) player.MoveLeft();
        }

        public void MoveRight(Player player, List<int>[,] walls)
        {
            if (player.CanMove(ArenaCommandEnum.MoveRight, walls)) player.MoveRight();
        }

        public void MoveUp(Player player, List<int>[,] walls)
        {
            if (player.CanMove(ArenaCommandEnum.MoveUp, walls)) player.MoveUp();
        }
    }
}
