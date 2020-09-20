using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class Grid : IReset
    {
        // TODO: load map sizes and other settings from server; hardcoding for prototype

        private List<Tile>[,] tiles = new List<Tile>[13,13]; // Tile matrix

        public bool listenForGrid = true;

        public Grid()
        {
            for(int x = 0; x < tiles.Length; x++)
            {
                for(int y = 0; y < tiles.Length; y++) 
                {
                    tiles[x, y] = new List<Tile>();                           
                }             
            }
        }

        /// <summary>
        /// Listener for changes in grid (primary client listener for server messages)
        /// </summary>
        public void ListenGrid()
        {
            while (listenForGrid)
            {


            }
        }

        public void UpdateGrid()
        {
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 13; y++)
                {
                    foreach(var tile in tiles[x, y])
                    {
                        tile.UpdateGfx();
                    }
                }
            }
        }

        public void UpdateTile(int x, int y, TileEnumerator.TileTypeEnum tileType, int layer)
        {
            tiles[x,y][layer].SetTileType(tileType);
        }

        public void UpdateTile(int x, int y, PowerUpEnumerator.PowerUpType powerUpType, int layer)
        {
            tiles[x,y][layer].SetPowerUpType(powerUpType);
        }

        public void Reset()
        {
            tiles = new List<Tile>[13, 13];
        }
    }
}
