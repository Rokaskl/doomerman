using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public sealed class ClientManager
    {
        private TilesGraphicsData tilesGraphicsData = new TilesGraphicsData();
        private static ClientManager instance = null;
        private static readonly object padlock = new object();

        public string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        private int currentPlayerID = -1;   // ID representing the Player (0-3)
        private int score;                  // NOT IMPLEMENTED
        private Grid grid;
        private bool isStarted = false;
        public bool isAlive = true;
        private Task drawTask = new Task(() => DrawQueue.Draw());

        ClientManager()
        {

        }

        public static ClientManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ClientManager();
                    }
                    return instance;
                }
            }
        }
        /// <summary>
        /// Returns the Player's ID (if it's set)
        /// </summary>
        /// <returns>currentPlayerID</returns>
        public int GetPlayerID()
        {
            if (IDIsSet())
            {
                return currentPlayerID;
            }

            throw new System.Exception("Trying to get Player's ID before setting it");
        }

        /// <summary>
        /// Sets the Player's ID
        /// </summary>
        /// <param name="id"></param>
        public void SetPlayerID(int id)
        {
            if (id >= 0 && id <= 3)
            {
                currentPlayerID = id;
                return;
            }

            throw new System.Exception(string.Concat("Trying to set Player's ID to an invalid value: ", id, ". Please considering using a number in range [0, 3]"));
        }

        /// <summary>
        /// Check's if the Player's ID is set
        /// </summary>
        /// <returns></returns>
        public bool IDIsSet()
        {
            if (currentPlayerID < 0)
                return false;
            else return true;
        }

        public void SetGrid(Grid _grid)
        {
            this.grid = _grid;
        }

        public Grid GetGrid()
        {
            return grid;
        }
        public void setIsStarted(bool value)
        {
            isStarted = value;
        }
        public bool getIsStarted()
        {
            return isStarted;
        }
        public void SetGridFromServer(List<int>[,] grid, int[] deadPlayers)
        {
            Parallel.For(0, 13, (x) =>
            {
                Parallel.For(0, 13, (y) =>
                {
                    List<Tile> tiles = new List<Tile>();
                    foreach (int intTile in grid[x, y])
                    {
                        Tile tile;

                        if (Tile.isTileAnimated((TileEnumerator.TileTypeEnum)intTile))
                        {
                            tile = new AnimatedTile(this.tilesGraphicsData.GetTilesGraphicsDataObject(intTile).FrameCount, true );
                            tile.SetTileGfx(this.tilesGraphicsData.GetTileGrapchicsObject(intTile));
                        }
                        else
                        {
                            tile = new StaticTile();
                            TileGraphics tileGraphics = new StaticTileGraphics();
                            tile.SetTileGfx(tileGraphics);
                        }

                        if (deadPlayers.Contains(intTile))
                        {
                            tile.SetTileType(TileEnumerator.TileTypeEnum.Dead);
                        }
                        else
                        {
                            tile.SetTileType((TileEnumerator.TileTypeEnum)intTile);
                        }
                        tile.SetTilePosition(x, y);
                        tiles.Add(tile);
                    }

                    Instance.GetGrid().SetTile(x, y, tiles);
                });
            });
            DrawQueue.Draw();
            //if(drawTask.Status != TaskStatus.Running)
            //    drawTask.Start();
        }

    }
}

