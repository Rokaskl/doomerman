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

namespace Server
{
    public class GameArena
    {
        public int Id;
        public List<Player> Players;
        private Grid grid;
        private LogicFacade Calculator;
        public List<IGameObject> gameObjects = new List<IGameObject>();

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

            var gameObject = new GameObject(new Coordinates(1, 2));
            var gameObject2 = new Lootable(gameObject);
            var gameObject3 = new Destroyable(gameObject2);

            var gameObject4 = new GameObject(new Coordinates(1, 2));
            var gameObject5 = new Pickable(gameObject4);

            gameObject3.AddLoot(gameObject5);


            gameObject3.PrintTags();
            Console.WriteLine("brrrrrrrrrrrrrrr");
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
                UpdateGrid();
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

            List<Player> CurrentPlayers = this.Players.ToList();
            foreach (Player player in CurrentPlayers)
            {
                if (!(player.Bomb is null))
                {
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
            CurrentPlayers.ForEach(x => x.Bomb = null);

            Notify();

        }
    }
}
