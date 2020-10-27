using Server.MapObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class WallsAdapter : Grid
    {
        Walls walls;
        public WallsAdapter(Walls walls)
        {
            this.walls = walls;
        }

        public List<int>[,] GetGrid()
        {

            int[,] oldWalls = walls.GetWalls();
            List<int>[,] newWalls = new List<int>[13,13];


            for(int x = 0; x < 13; x++)
            {
                for(int y = 0; y < 13; y++)
                {
                    newWalls[x, y] = new List<int>() { oldWalls[x, y] };
                    UpdateTile(x, y, newWalls[x, y]);
                }
            }

            return newWalls;
        }
    }
}
