using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.constants;
using Server.MapObject;
using Server.MapObject.PowerUps;
using static Server.TileEnumerator;

namespace Server.ChainOfRespPattern
{
    public class PlayersAndBombsHandler<T> : IHandler where T : Arena
    {
        private T context;
        private IHandler successor;
        public PlayersAndBombsHandler(T context)
        {
            this.context = context;
        }

        public PlayersAndBombsHandler()
        {

        }

        public void HandleRequest()
        {
            this.AddPlayersAndBombsToGrid();
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

        private void AddPlayersAndBombsToGrid()
        {
            //List<Player> CurrentPlayers = context.Players.ToList();
            Explosive prototype = new Explosive();
            context.Players.Copy().CreateIterator().ForEach(player =>
            {
                if (!player.Bomb.Droped)
                {
                    player.Bomb.Droped = true;
                    if (IsBombValid(player) && player.BombLimit > player.BombCount)
                    {
                        Console.WriteLine(string.Format("addBombsToGrid x:{0}y:{1}", player.Bomb.GetCords().X, player.Bomb.GetCords().Y));
                        var copy = prototype.Clone();
                        copy.SetCords((Coordinates) player.Bomb.GetCords().Clone());
                        copy.Radius = player.Bomb.Radius;
                        context.AddGameObject(copy);
                        player.BombCount++;
                        RemoveBomb(copy, player);
                    }
                }
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                context.grid.UpdateTile(playerX, playerY, cleanTile);
            });
        }

        private bool IsBombValid(Player player)
        {
            Coordinates xy = player.Bomb.GetCords().Clone() as Coordinates;
            ;
            if (context.grid.GetTile(xy.X, xy.Y).Contains((int) TileTypeEnum.Bomb))
            {
                return false;
            }
            return true;
        }

        private async void RemoveBomb(Explosive bomb, Player player)
        {
            await Task.Factory.StartNew(() =>
            {
                var fc = new PowerUpFactory();

                Thread.Sleep(bomb.Time);
                Coordinates xy = bomb.GetCords();
                context.grid.RemoveFromTile(xy.X, xy.Y, (int) TileTypeEnum.Bomb);
                context.RemoveGameObject(bomb, xy.X, xy.Y);
                ExecuteExplosion(bomb);
                context.UpdateRequired = true;
                player.BombCount--;

            });
        }

        private void ExecuteExplosion(Explosive bomb)
        {
            Flame flames = new Flame(bomb.GetCords());

            flames.flames[bomb.GetCords().X, bomb.GetCords().Y] = (int) TileTypeEnum.FlameC;
            context.grid.ReturnPlayersAt(bomb.GetCords().X, bomb.GetCords().Y).ForEach(z => context.Players[z - 1].Alive = false);

            int x = ((Coordinates) bomb.GetCords().Clone()).X;
            int y = ((Coordinates) bomb.GetCords().Clone()).Y;
            int radius = bomb.Radius;

            for (int i = 1; i < radius; i++)
            {
                if ((x - i) >= 0)
                {
                    if (context.walls[x - i, y] == (int) TileTypeEnum.Wall)
                        break;
                    if (context.walls[x - i, y] == (int) TileTypeEnum.DestroyableWall)
                    {
                        context.grid.AddToTile(x - i, y, (int) TileTypeEnum.FlameH);
                        context.walls[x - i, y] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x - i, y));
                        if (!(temp is null))
                            context.AddGameObject(temp);
                        break;
                    }
                    context.grid.ReturnPlayersAt(x - i, y).ForEach(z => context.Players[z - 1].Alive = false);
                    bool brk = false;
                    context.grid.ReturnPowersAt(x - i, y).ForEach(z => { context.RemoveGameObjectAt(x - i, y); brk = true; });
                    flames.flames[x - i, y] = (int) TileTypeEnum.FlameH;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((x + i) <= 12)
                {
                    if (context.walls[x + i, y] == (int) TileTypeEnum.Wall)
                        break;
                    if (context.walls[x + i, y] == (int) TileTypeEnum.DestroyableWall)
                    {
                        context.walls[x + i, y] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x + i, y));
                        if (!(temp is null))
                            context.AddGameObject(temp);
                        break;
                    }
                    context.grid.ReturnPlayersAt(x + i, y).ForEach(x => context.Players[x - 1].Alive = false);
                    bool brk = false;
                    context.grid.ReturnPowersAt(x + i, y).ForEach(z => { context.RemoveGameObjectAt(x + i, y); brk = true; });
                    flames.flames[x + i, y] = (int) TileTypeEnum.FlameH;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((y - i) >= 0)
                {
                    if (context.walls[x, y - i] == (int) TileTypeEnum.Wall)
                        break;
                    if (context.walls[x, y - i] == (int) TileTypeEnum.DestroyableWall)
                    {
                        context.walls[x, y - i] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x, y - i));
                        if (!(temp is null))
                            context.AddGameObject(temp);
                        break;
                    }
                    context.grid.ReturnPlayersAt(x, y - i).ForEach(x => context.Players[x - 1].Alive = false);
                    bool brk = false;
                    context.grid.ReturnPowersAt(x, y - i).ForEach(z => { context.RemoveGameObjectAt(x, y - i); ; brk = true; });
                    flames.flames[x, y - i] = (int) TileTypeEnum.FlameV;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((y + i) <= 12)
                {
                    if (context.walls[x, y + i] == (int) TileTypeEnum.Wall)
                        break;
                    if (context.walls[x, y + i] == (int) TileTypeEnum.DestroyableWall)
                    {
                        context.walls[x, y + i] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x, y + i));
                        if (!(temp is null))
                            context.AddGameObject(temp);
                        break;
                    }
                    context.grid.ReturnPlayersAt(x, y + i).ForEach(x => context.Players[x - 1].Alive = false);
                    bool brk = false;
                    context.grid.ReturnPowersAt(x, y + i).ForEach(z => { context.RemoveGameObjectAt(x, y + i); brk = true; });
                    flames.flames[x, y + i] = (int) TileTypeEnum.FlameV;
                    if (brk)
                        break;
                }
            }
            FlamesAtInterval(flames, Constants.FlameExposureTime);

        }

        private async void FlamesAtInterval(Flame flame, int wait)
        {
            await Task.Factory.StartNew(() =>
            {
                var xy = flame.GetCords();
                context.flames.Add(flame);

                Thread.Sleep(wait);

                context.flames.RemoveAll(z => z.GetCords().X == xy.X && z.GetCords().Y == xy.Y);
                context.RemoveGameObject(flame, xy.X, xy.Y);
                context.UpdateRequired = true;
            });
        }
    }
}
