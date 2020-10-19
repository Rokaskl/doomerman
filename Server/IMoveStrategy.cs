using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public interface IMoveStrategy
    {
        void MoveUp(Player player, int[,] walls);
        void MoveDown(Player player, int[,] walls);
        void MoveLeft(Player player, int[,] walls);
        void MoveRight(Player player, int[,] walls);
    }
}
