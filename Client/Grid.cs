using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class Grid
    {
        // TODO: load map sizes and other settings from server; hardcoding for prototype

        private Tile[,] tiles = new Tile[13,13]; // Tile matrix

        public bool listenForGrid = true;

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
                    tiles[x,y].UpdateGfx();
                }
            }
        }

        public void UpdateTile(int x, int y, TileEnumerator.TileTypeEnum tileType)
        {
            tiles[x,y].SetTileType(tileType);
            tiles[x,y].UpdateGfx();            // Updates which image to use (maybe will make it private and do an auto update when setting type)
        }

        public void UpdateTile(int x, int y, PowerUpEnumerator.PowerUpType powerUpType)
        {
            tiles[x,y].SetPowerUpType(powerUpType);
            tiles[x,y].UpdateGfx();
        }
    }
}
