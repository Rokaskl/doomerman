using System;
using System.Collections.Generic;
using System.Text;
using static Server.TileEnumerator;

namespace Server.ChainOfRespPattern
{
    public class WallsHandler<T> : ChainTemplate where T : Arena
    {
        private T context;
        private IHandler successor;
        public WallsHandler(T context)
        {
            this.context = context;
        }

        public WallsHandler()
        {

        }

        public override void HandleRequest()
        {
            this.AddWallsToGrid();
            if (this.successor != null)
            {
                this.successor.HandleRequest();
            }
        }
        public override IHandler SetSuccessor(IHandler successor)
        {
            this.successor = successor;
            return this.successor;
        }

        public void AddWallsToGrid()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    switch (context.walls[i, j])
                    {
                        case (int) TileTypeEnum.Wall:
                            context.grid.AddToTile(i, j, (int) TileTypeEnum.Wall);
                            break;
                        case (int) TileTypeEnum.DestroyableWall:
                            context.grid.AddToTile(i, j, (int) TileTypeEnum.DestroyableWall);
                            break;
                        case (int) TileTypeEnum.Water:
                            context.grid.AddToTile(i, j, (int) TileTypeEnum.Water);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
