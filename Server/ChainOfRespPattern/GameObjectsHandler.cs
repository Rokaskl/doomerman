using System;
using System.Collections.Generic;
using System.Text;
using Server.MapObject.PowerDowns;
using Server.MapObject.PowerUps;
using static Server.TileEnumerator;

namespace Server.ChainOfRespPattern
{
    public class GameObjectsHandler<T> : ChainTemplate where T : Arena
    {
        private T context;
        private IHandler successor;
        public GameObjectsHandler(T context)
        {
            this.context = context;
        }

        public GameObjectsHandler()
        {

        }

        public override void HandleRequest()
        {
            this.AddGameObjsToGrid();
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

        private void AddGameObjsToGrid()
        {
            foreach (IGameObject obj in context.gameObjects)
            {
                switch (obj)
                {
                    case Explosive _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.Bomb);
                        break;
                    case BombLimitIncrease _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUIncreaseBombLimit);
                        break;
                    case BombLimitDecrease _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUDecreaseBombLimit);
                        break;
                    case BombFireIncrease _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUIncreaseBombRange);
                        break;
                    case BombFireDecrease _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUDecreaseBombRange);
                        break;
                    case BombKick _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUBombKick);
                        break;
                    case TemporarySwim _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUTemporarySwim);
                        break;
                    case TemporaryJump _:
                        context.grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int) TileTypeEnum.PUTemporaryJump);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
