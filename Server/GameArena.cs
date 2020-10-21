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

namespace Server
{
    public class GameArena
    {
        public int Id;
        public List<Player> Players;
        public Grid grid; 
        private LogicFacade Calculator;
        public List<IGameObject> gameObjects = new List<IGameObject>();
        private Lobby lobby;
        public bool UpdateRequired;
        public int[,] walls;
        public bool isStarted = false;
        public void RemoveGameObject(IGameObject gameObject, int x, int y)
        {
            gameObjects.RemoveAll(z => z is null); // kartais atsiranda null, atrodo niekur neprilyginu jokio gameobject i null
            //cj labai expensive dalykas, kiekvienam updatui. padekit sugalvot geresni
            gameObjects.RemoveAll(z => z.GetType() == gameObject.GetType() && z.GetCords().X == x && z.GetCords().Y == y);
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
            this.grid = new Grid();
            walls = Walls.walls;

            UpdateAtInterval(Constants.UpdateInterval);

            GameObject gameObject = new GameObject(new Coordinates(1, 1));
            Destroyable destryable = new Destroyable(gameObject);
            Lootable lootable = new Lootable(destryable);
            Pickable pickable = new Pickable(new GameObject(new Coordinates(1, 2)));
            lootable.AddLoot(pickable);
            lootable.GetLoot();

            Console.WriteLine(lootable);
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
                player.Update(this.grid);
            }
        }
        public void StartGame()
        {
            isStarted = true;
            UpdateRequired = true;

        }
        public void UpdateGrid()
        {
            CheckForPowers();
            grid.Clean();
            AddWallsToGrid();
            AddPlayersAndBombsToGrid();
            AddGameObjsToGrid();

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
                int x = bomb.GetCords().X;
                int y = bomb.GetCords().Y;
                Thread.Sleep(bomb.Time);
                grid.RemoveFromTile(x, y, (int)TileTypeEnum.Bomb);
                RemoveGameObject(bomb, x, y);
                ExecuteExplosion(x, y, bomb.Radius);           
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
                    case Explosive bomb:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.Bomb);
                        break;
                    case BombLimitIncrease bli:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUIncreaseBombLimit);
                        break;
                    case BombLimitDecrease bld:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUDecreaseBombLimit);
                        break;
                    case BombFireIncrease bfi:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUIncreaseBombRange);
                        break;
                    case BombFireDecrease bfd:
                        grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, (int)TileTypeEnum.PUDecreaseBombRange);
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddPlayersAndBombsToGrid()
        {
            List<Player> CurrentPlayers = this.Players.ToList();
            foreach (Player player in CurrentPlayers)
            {
                if (!player.Bomb.Droped)
                {
                    player.Bomb.Droped = true;
                    if (IsBombValid(player) && player.BombLimit > player.BombCount)
                    {
                        Console.WriteLine(string.Format("addBombsToGrid x:{0}y:{1}", player.Bomb.GetCords().X, player.Bomb.GetCords().Y));
                        AddGameObject(new Explosive(player.Bomb.GetCords().X, player.Bomb.GetCords().Y));
                        player.BombCount++;
                        RemoveBomb(player.Bomb, player);
                    }
                }
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
            }
        }
        private void AddWallsToGrid()
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
                        default:
                            break;
                    }
                }
            }
        }
        private bool IsBombValid(Player player)
        {
            int x = player.Bomb.GetCords().X;
            int y = player.Bomb.GetCords().Y;
            if (grid.GetTile(x, y).Contains((int)TileTypeEnum.Bomb))
            {
                return false;
            }
            return true;
        }
        private void ExecuteExplosion(int x, int y, int radius)
        {
            var fc = new PickableFactoryProvider();
            for (int i = 1; i <= radius; i++)
            {
                if ((x - i) >= 0)
                {
                    if (walls[x - i, y] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x - i, y] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x - i, y] = 0;
                        var temp = fc.GetRandom(new Coordinates(x - i, y));
                        if(!(temp is null))
                        AddGameObject(temp);
                        break;
                    }
                }
            }
            for (int i = 1; i <= radius; i++)
            {

                if ((x + i) <= 12)
                {
                    if (walls[x + i, y] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x + i, y] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x + i, y] = 0;
                        var temp = fc.GetRandom(new Coordinates(x + i, y));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                }
            }
            for (int i = 1; i <= radius; i++)
            {

                if ((y - i) >= 0)
                {
                    if (walls[x, y - i] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x, y - i] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x, y - i] = 0;
                        var temp = fc.GetRandom(new Coordinates(x, y - i));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                }
            }
            for (int i = 1; i <= radius; i++)
            {

                if ((y + i) <= 12)
                {
                    if (walls[x, y + i] == (int)TileTypeEnum.Wall)
                        break;
                    if (walls[x, y + i] == (int)TileTypeEnum.DestroyableWall)
                    {
                        walls[x, y + i] = 0;
                        var temp = fc.GetRandom(new Coordinates(x, y + i));
                        if (!(temp is null))
                            AddGameObject(temp);
                        break;
                    }
                }
            }
        }
    }
}
