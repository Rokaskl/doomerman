using System;
using System.Collections.Generic;
using System.Text;
using Server.MapObject;
using static Server.TileEnumerator;

namespace Server.ChainOfRespPattern
{
    public class FlamesHandler<T> : ChainTemplate where T : Arena
    {
        private T context;
        private IHandler successor;

        public FlamesHandler(T context)
        {
            this.context = context;
        }

        public FlamesHandler()
        {

        }

        public override void HandleRequest()
        {
            this.AddFlamesToGrid();
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

        private void AddFlamesToGrid()
        {
            foreach (Flame item in context.flames)
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        if (item.flames[i, j] > 0
                            && !(context.grid.GetGrid()[i, j].Contains((int) TileTypeEnum.FlameH)
                            || context.grid.GetGrid()[i, j].Contains((int) TileTypeEnum.FlameV)
                            || context.grid.GetGrid()[i, j].Contains((int) TileTypeEnum.FlameC)))
                        {
                            context.grid.AddToTile(i, j, item.flames[i, j]);
                        }
                    }
                }
            }
        }
    }
}
