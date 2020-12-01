using System;
using System.Collections.Generic;
using System.Text;
using Server.MapObject.PowerDowns;
using Server.MapObject.PowerUps;
using static Server.TileEnumerator;

namespace Server.ChainOfRespPattern
{
    public class PowersHandler<T> : IHandler where T : Arena
    {
        private T context;
        private IHandler successor;
        public PowersHandler(T context)
        {
            this.context = context;
        }

        public PowersHandler()
        {

        }

        public void HandleRequest()
        {
            this.CheckForPowers();
            if (this.successor != null)
            {
                this.successor.HandleRequest();
            }
        }
        public IHandler SetSuccessor(IHandler successor)
        {
            this.successor = successor;
            return this.successor;
        }

        private void CheckForPowers()
        {
            foreach (Player player in context.Players)
            {
                context.grid.GetGrid()[player.xy.X, player.xy.Y].ForEach(x =>
                {
                    switch (x)
                    {
                        case (int) TileTypeEnum.PUIncreaseBombRange:
                            {
                                player.Bomb.IncRadius();
                                context.RemoveGameObject(new BombFireIncrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int) TileTypeEnum.PUDecreaseBombRange:
                            {
                                player.Bomb.DecRadius();
                                context.RemoveGameObject(new BombFireDecrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int) TileTypeEnum.PUIncreaseBombLimit:
                            {
                                player.IncBombLimit();
                                context.RemoveGameObject(new BombLimitIncrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int) TileTypeEnum.PUDecreaseBombLimit:
                            {
                                player.DecBombLimit();
                                context.RemoveGameObject(new BombLimitDecrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int) TileTypeEnum.PUBombKick:
                            {
                                player.ChangeStrategy(new MoveKickStrategy());
                                context.RemoveGameObject(new BombKick(), player.xy.X, player.xy.Y);
                                break;
                            }

                        case (int) TileTypeEnum.PUTemporarySwim:
                            {
                                player.ChangeStrategy(new MoveSwimStrategy());
                                context.RemoveGameObject(new TemporarySwim(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int) TileTypeEnum.PUTemporaryJump:
                            {
                                player.ChangeStrategy(new MoveJumpStrategy());
                                context.RemoveGameObject(new TemporaryJump(), player.xy.X, player.xy.Y);
                                break;
                            }

                    }
                });

            }
        }
    }


}
