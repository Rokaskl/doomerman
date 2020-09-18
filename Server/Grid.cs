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
           
            Console.WriteLine("Grid {0} X {0} created ", _size);

        }
        public int[,] getGrid()
        {
            return this._grid;
        }
        public int getSize()
        {
            return this._size;
        }
        public bool updateField(int i, int j,int value)
        {
            try
            {
                _grid[i, j] = value;
                Notify();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                return false;
            }
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
