using Microsoft.VisualBasic.FileIO;
using Server.FacadePattern;
using Server.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.GameLobby;
using Server.MapObject;
using Newtonsoft.Json;
using static Server.TileEnumerator;
using Server.MapObject.PowerUps;
using Server.constants;
using Server.MapObject.PowerDowns;
using System.IO;

namespace Server
{
    public class GameArena : IGameArenaObserver
    {
        public int Id;
        public List<Player> Players;
        public Grid grid;
        private LogicFacade Calculator;
        public List<IGameObject> gameObjects = new List<IGameObject>();
        public List<IGameObject> flames = new List<IGameObject>();
        private Lobby lobby;
        public bool UpdateRequired;
        public int[,] walls;
        public Walls wallsObj = new Walls();
        public bool isStarted = false;
        public void RemoveGameObject(IGameObject gameObject, int x, int y)
        {
            gameObjects.RemoveAll(z => z is null); // kartais atsiranda null, atrodo niekur neprilyginu jokio gameobject i null
            //cj labai expensive dalykas, kiekvienam updatui. padekit sugalvot geresni
            gameObjects.RemoveAll(z => z.GetType() == gameObject.GetType() && z.GetCords().X == x && z.GetCords().Y == y);
        }
        public void RemoveGameObjectAt(int x, int y)
        {
            gameObjects.RemoveAll(z => z is null); // kartais atsiranda null, atrodo niekur neprilyginu jokio gameobject i null
            //cj labai expensive dalykas, kiekvienam updatui. padekit sugalvot geresni
            gameObjects.RemoveAll(z => z.GetTags().Contains("Pickable") && z.GetCords().X == x && z.GetCords().Y == y);
        }
        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        public GameArena(int id)
        {
            this.Id = id;
            this.Players = new List<Player>();
            this.lobby = new Lobby(this);
            this.Calculator = new LogicFacade(this, lobby);

            this.grid = new WallsAdapter(wallsObj);
            walls = wallsObj.GetWalls();
            UpdateAtInterval(Constants.UpdateInterval);
        }
        public void AddPlayer(Player player)
        {
            //player.Update(grid);
            this.Players.Add(player);
            player.sender.Send(1, player.User.Id.ToString());//Answer to handshake
            new PlayerService(player, this.Calculator);
        }

        public void Notify()
        {

            foreach (Player player in Players)
            {
                player.Update(this.grid, DeadPlayers());
            }
        }
        public List<int> DeadPlayers()
        {
            var deads = new List<int>();
            Players.ForEach(x =>
            {
                if (!x.Alive) deads.Add(x.User.Id);
            });
            return deads;
        }
        public void StartGame()
        {
            isStarted = true;
            UpdateRequired = true;
        }

        public bool KickBomb(Coordinates bombCord, Explosive.KickDirection dir)
        {
            List<int> cantKickInto = new List<int>() { (int)TileTypeEnum.Wall, (int)TileTypeEnum.DestroyableWall, (int)TileTypeEnum.Water, (int)TileTypeEnum.Bomb };

            foreach (var go in gameObjects)
            {
                if (go.GetCords().X == bombCord.X && go.GetCords().Y == bombCord.Y)
                {
                    if (go is Explosive)
                    {
                        switch (dir)
                        {
                            case Explosive.KickDirection.Up:
                                if (go.GetCords().Y > 0 && !cantKickInto.Contains(walls[go.GetCords().X, go.GetCords().Y - 1]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X, go.GetCords().Y - 1));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);

                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Down:

                                if (go.GetCords().Y < 12 && !cantKickInto.Contains(walls[go.GetCords().X, go.GetCords().Y + 1]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X, go.GetCords().Y + 1));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Left:
                                if (go.GetCords().X > 0 && !cantKickInto.Contains(walls[go.GetCords().X - 1, go.GetCords().Y]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X - 1, go.GetCords().Y));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                            case Explosive.KickDirection.Right:
                                if (go.GetCords().X < 12 && !cantKickInto.Contains(walls[go.GetCords().X + 1, go.GetCords().Y]))
                                {
                                    grid.RemoveFromTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    go.SetCords(new Coordinates(go.GetCords().X + 1, go.GetCords().Y));
                                    grid.AddToTile(go.GetCords().X, go.GetCords().Y, (int)TileTypeEnum.Bomb);
                                    return true;
                                }
                                break;
                        }
                    }
                }
            }

            return false;
        }
        public void UpdateGrid()
        {
            CheckForPowers();
            grid.Clean();
            AddWallsToGrid();
            AddPlayersAndBombsToGrid();
            AddGameObjsToGrid();
            AddFlamesToGrid();
            Notify();
            UpdateRequired = false;

        }
        private void CheckForPowers()
        {
            foreach (Player player in Players)
            {
                grid.GetGrid()[player.xy.X, player.xy.Y].ForEach(x =>
                {
                    switch (x)
                    {
                        case (int)TileTypeEnum.PUIncreaseBombRange:
                            {
                                player.Bomb.IncRadius();
                                RemoveGameObject(new BombFireIncrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int)TileTypeEnum.PUDecreaseBombRange:
                            {
                                player.Bomb.DecRadius();
                                RemoveGameObject(new BombFireDecrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int)TileTypeEnum.PUIncreaseBombLimit:
                            {
                                player.IncBombLimit();
                                RemoveGameObject(new BombLimitIncrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int)TileTypeEnum.PUDecreaseBombLimit:
                            {
                                player.DecBombLimit();
                                RemoveGameObject(new BombLimitDecrease(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int)TileTypeEnum.PUBombKick:
                            {
                                player.ChangeStrategy(new MoveKickStrategy());
                                RemoveGameObject(new BombKick(), player.xy.X, player.xy.Y);
                                break;
                            }

                        case (int)TileTypeEnum.PUTemporarySwim:
                            {
                                player.ChangeStrategy(new MoveSwimStrategy());
                                RemoveGameObject(new TemporarySwim(), player.xy.X, player.xy.Y);
                                break;
                            }
                        case (int)TileTypeEnum.PUTemporaryJump:
                            {
                                player.ChangeStrategy(new MoveJumpStrategy());
                                RemoveGameObject(new TemporaryJump(), player.xy.X, player.xy.Y);
                                break;
                            }

                    }
                });

            }
        }
        private async void UpdateAtInterval(int timeout)
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (UpdateRequired)
                        UpdateGrid();

                    Thread.Sleep(timeout);
                }
            });
        }
        private async void RemoveBomb(Explosive bomb, Player player)
        {
            await Task.Factory.StartNew(() =>
            {
                var fc = new PowerUpFactory();

                Thread.Sleep(bomb.Time);
                Coordinates xy = bomb.GetCords();
                grid.RemoveFromTile(xy.X, xy.Y, (int)TileTypeEnum.Bomb);
                RemoveGameObject(bomb, xy.X, xy.Y);
                ExecuteExplosion(bomb);
                UpdateRequired = true;
                player.BombCount--;

            });
        }
        private void AddGameObjsToGrid()
        {
            foreach (IGameObject obj in gameObjects)
            {
                switch (obj)
                {
                    case Explosive _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.Bomb);
                        break;
                    case BombLimitIncrease _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUIncreaseBombLimit);
                        break;
                    case BombLimitDecrease _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUDecreaseBombLimit);
                        break;
                    case BombFireIncrease _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUIncreaseBombRange);
                        break;
                    case BombFireDecrease _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUDecreaseBombRange);
                        break;
                    case BombKick _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUBombKick);
                        break;
                    case TemporarySwim _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUTemporarySwim);
                        break;
                    case TemporaryJump _:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUTemporaryJump);
                        break;

                    default:
                        break;
                }
            }
        }
        private void AddPlayersAndBombsToGrid()
        {
            List<Player> CurrentPlayers = this.Players.ToList();
            Explosive prototype = new Explosive();
            foreach (Player player in CurrentPlayers)
            {
                if (!player.Bomb.Droped)
                {
                    player.Bomb.Droped = true;
                    if (IsBombValid(player) && player.BombLimit > player.BombCount)
                    {
                        Console.WriteLine(string.Format("addBombsToGrid x:{0}y:{1}", player.Bomb.GetCords().X, player.Bomb.GetCords().Y));
                        var copy = prototype.Clone();
                        copy.SetCords((Coordinates)player.Bomb.GetCords().Clone());
                        copy.Radius = player.Bomb.Radius;
                        AddGameObject(copy);
                        player.BombCount++;
                        RemoveBomb(copy, player);
                    }
                }
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
            }
        }
        public void AddWallsToGrid()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    switch (walls[i, j])
                    {
                        case (int)TileTypeEnum.Wall:
                            grid.AddToTile(i, j, (int)TileTypeEnum.Wall);
                            break;
                        case (int)TileTypeEnum.DestroyableWall:
                            grid.AddToTile(i, j, (int)TileTypeEnum.DestroyableWall);
                            break;
                        case (int)TileTypeEnum.Water:
                            grid.AddToTile(i, j, (int)TileTypeEnum.Water);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private bool IsBombValid(Player player)
        {
            Coordinates xy = player.Bomb.GetCords().Clone() as Coordinates; ;
            if (grid.GetTile(xy.X, xy.Y).Contains((int)TileTypeEnum.Bomb))
            {
                return false;
            }
            return true;
        }
        private void ExecuteExplosion(Explosive bomb)
        {
            Flame flames = new Flame(bomb.GetCords());

            flames.flames[bomb.GetCords().X, bomb.GetCords().Y] = (int)TileTypeEnum.FlameC;
            grid.ReturnPlayersAt(bomb.GetCords().X, bomb.GetCords().Y).ForEach(z => Players[z - 1].Alive = false);

            int x = ((Coordinates)bomb.GetCords().Clone()).X;
            int y = ((Coordinates)bomb.GetCords().Clone()).Y;
            int radius = bomb.Radius;

            for (int i = 1; i < radius; i++)
            {
                if ((x - i) >= 0)
                {
                    if (walls[x - i, y] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x - i, y] == (int)TileTypeEnum.DestroyableWall)
                    {
                        grid.AddToTile(x - i, y, (int)TileTypeEnum.FlameH);
                        walls[x - i, y] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x - i, y));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                    grid.ReturnPlayersAt(x - i, y).ForEach(z => Players[z - 1].Alive = false);
                    bool brk = false;
                    grid.ReturnPowersAt(x - i, y).ForEach(z => { RemoveGameObjectAt(x - i, y); brk = true; });
                    flames.flames[x - i, y] = (int)TileTypeEnum.FlameH;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((x + i) <= 12)
                {
                    if (walls[x + i, y] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x + i, y] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x + i, y] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x + i, y));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                    grid.ReturnPlayersAt(x + i, y).ForEach(x => Players[x - 1].Alive = false);
                    bool brk = false;
                    grid.ReturnPowersAt(x + i, y).ForEach(z => { RemoveGameObjectAt(x + i, y); brk = true; });
                    flames.flames[x + i, y] = (int)TileTypeEnum.FlameH;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((y - i) >= 0)
                {
                    if (walls[x, y - i] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x, y - i] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x, y - i] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x, y - i));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                    grid.ReturnPlayersAt(x, y - i).ForEach(x => Players[x - 1].Alive = false);
                    bool brk = false;
                    grid.ReturnPowersAt(x, y - i).ForEach(z => { RemoveGameObjectAt(x, y - i);; brk = true; });
                    flames.flames[x, y - i] = (int)TileTypeEnum.FlameV;
                    if (brk)
                        break;
                }
            }
            for (int i = 1; i < radius; i++)
            {

                if ((y + i) <= 12)
                {
                    if (walls[x, y + i] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x, y + i] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x, y + i] = 0;
                        var temp = PickableFactoryProvider.GetRandom(new Coordinates(x, y + i));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                    grid.ReturnPlayersAt(x, y + i).ForEach(x => Players[x - 1].Alive = false);
                    bool brk = false;
                    grid.ReturnPowersAt(x, y + i).ForEach(z => { RemoveGameObjectAt(x, y + i); brk = true; });
                    flames.flames[x, y + i] = (int)TileTypeEnum.FlameV;
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
                flames.Add(flame);

                Thread.Sleep(wait);

                flames.RemoveAll(z => z.GetCords().X == xy.X && z.GetCords().Y == xy.Y);
                RemoveGameObject(flame, xy.X, xy.Y);
                UpdateRequired = true;
            });
        }
        private void AddFlamesToGrid()
        {
            foreach (Flame item in flames)
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        if (item.flames[i, j] > 0
                            && !(grid.GetGrid()[i, j].Contains((int)TileTypeEnum.FlameH)
                            || grid.GetGrid()[i, j].Contains((int)TileTypeEnum.FlameV)
                            || grid.GetGrid()[i, j].Contains((int)TileTypeEnum.FlameC)))
                        {
                            grid.AddToTile(i, j, item.flames[i, j]);
                        }
                    }
                }
            }
        }
    }
}
