using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public interface IMoveStrategy
    {
        void MoveUp(Player player, List<int>[,] walls);
        void MoveDown(Player player, List<int>[,] walls);
        void MoveLeft(Player player, List<int>[,] walls);
        void MoveRight(Player player, List<int>[,] walls);
    }
}
