using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GameArena
    {
        public int Id;
        public List<Player> Players;
        private Grid grid;
        private GameLogic Calculator;
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
            this.Calculator = new GameLogic(this);
            this.grid = new Grid();

            var gameObject = new GameObject(new Coordinates(1, 2));
            var gameObject2 = new Destroyable(gameObject);
            var gameObject3 = new Lootable(gameObject2);
            Console.WriteLine(gameObject3.GetCoordinates());
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
        public void UpdateGrid()
        {
            grid.Clean();

            //Add players to grid
            List<Player> CurrentPlayers = this.Players.ToList();
            foreach (Player player in CurrentPlayers)
            {
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
            }


           Notify();

        }
    }
}
