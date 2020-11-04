﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Server
{
    public class Grid
    {
        private List<int>[,] _grid;
        private int _size;

        public Grid(int size=13)
        {
            this._grid = new List<int>[size,size];
            
            this._size = size;
            this.Clean();
            Console.WriteLine("Grid {0} X {0} created ", _size);

        }
        public List<int>[,] GetGrid()
        {
            return this._grid;
        }
        public int getSize()
        {
            return this._size;
        }
        public List<int> ReturnPowersAt(int i, int j)
        {
            var players = new List<int>();

            _grid[i, j].ForEach(x => {
                if (x >= (int)TileEnumerator.TileTypeEnum.PUIncreaseBombRange && x <= (int)TileEnumerator.TileTypeEnum.PUTemporarySwim)
                {
                    players.Add(x);
                }
            });
            return players;
        }
        public List<int> ReturnPlayersAt(int i, int j)
        {
            var players = new List<int>();

            _grid[i, j].ForEach(x => { 
                if(x>=1 && x <=4)
                {
                    players.Add(x);
                }
            });
            return players;
        }
        public bool RemoveFromTile(int i, int j, int value)
        {
            try
            {
                _grid[i, j].Remove(value);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                return false;
            }
        }
        public bool AddToTile(int i, int j, int value)
        {
            try
            {
                _grid[i, j].Add(value);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                return false;
            }
        }
        public bool UpdateTile(int i, int j,List<int> value)
        {
            try
            {
                _grid[i, j] = value;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                return false;
            }
        }
        public List<int> GetTile(int i, int j)
        {
            return this._grid[i,j];
        }
        public void Clean()
        {
            for (int i = 0; i < this._size; i++)
            {
                for (int j = 0; j < this._size; j++)
                {

                    this._grid[i, j] = new List<int>();
                }

            }
        }
    }
}
