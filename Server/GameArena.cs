using Microsoft.VisualBasic.FileIO;
using Server.FacadePattern;
using Server.Logic;
using Server.MapObject;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class GameArena
    {
        public int Id;
        public List<Player> Players;
        private Grid grid;
        private LogicFacade Calculator;
        private bool UpdateBombRequired;
        public List<IGameObject> gameObjects = new List<IGameObject>();
        public int[,] walls;
        public void RemoveGameObject(IGameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        public GameArena(int id)
        {

            this.Id = id;
            this.Players = new List<Player>();
            this.Calculator = new LogicFacade(this);
            this.grid = new Grid();
            UpdateBombRequired = false;
            walls = Walls.walls;

            var gameObject = new GameObject(new Coordinates(1, 2));
            var gameObject2 = new Lootable(gameObject);
            var gameObject3 = new Destroyable(gameObject2);

            var gameObject4 = new GameObject(new Coordinates(1, 2));
            var gameObject5 = new Pickable(gameObject4);



            gameObject3.AddLoot(gameObject5);
            UpdateAtInterval(50);

            gameObject3.PrintTags();
            Console.WriteLine("brrrrrrrrrrrrrrr");
        }
        private async void UpdateAtInterval(int timeout)
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (UpdateBombRequired)
                    {
                        UpdateGrid();
                    }

                    Thread.Sleep(timeout);
                }
            });
        }
        public void AddPlayer(Player player)
        {
            player.Update(grid);
            this.Players.Add(player);
            new PlayerService(player, this.Calculator);
        }

        public void Notify()
        {
            foreach (Player player in Players)
            {
                player.Update(this.grid);
            }

        }
        private async void RemoveBomb(int x, int y)
        {
            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000); // kas 3 sekundes
                grid.RemoveFromTile(x, y, 4); // 4 - bomba
                gameObjects.RemoveAt(0); // seniausia bomba
                UpdateBombRequired = true;
            });
        }
        private void AddGameObjsToGrid()
        {
            foreach (IGameObject obj in gameObjects)
            {
                if (obj is Explosive)
                {
                    grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, 4);

                }
            }
        }
        public void UpdateGrid()
        {
            grid.Clean();
            //Add players to grid
            AddWallsToGrid();
            List<Player> CurrentPlayers = this.Players.ToList();
            foreach (Player player in CurrentPlayers)
            {
                if (!player.Bomb.Droped)
                {
                    player.Bomb.Droped = true;
                    gameObjects.Add(new Explosive(player.Bomb.GetCords().X,
                        player.Bomb.GetCords().Y));             
                    RemoveBomb(player.Bomb.GetCords().X, player.Bomb.GetCords().Y);
                }
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
                AddGameObjsToGrid();
            }
            UpdateBombRequired = false;

            Notify();

        }
        private void AddWallsToGrid()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (walls[i, j] > 0)
                    {
                        var value = new List<int>();
                        value.Add(walls[i, j]);
                        grid.UpdateTile(i, j, value);
                    }
                }
            }
        }
    }
}
