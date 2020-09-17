using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Server
{
    public class Grid
    {
        private int[,] _grid;
        private int _size;

        private List<IPlayer> _players = new List<IPlayer>();

        public Grid(int size=13)
        {
            this._grid = new int[size,size];
            this._size = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _grid[i, j] = 0;
                }

            }
            Console.WriteLine("Grid {0} X {0} created ", _size);

        }

        public void Notify()
        {
            foreach (Player player in _players)
            {
                player.Update(this);
            }

        }


    }
}
