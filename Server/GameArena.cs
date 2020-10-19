﻿using Microsoft.VisualBasic.FileIO;
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

namespace Server
{
    public class GameArena
    {
        public int Id;
        public List<Player> Players;
        private Grid grid;
        private LogicFacade Calculator;
        public List<IGameObject> gameObjects = new List<IGameObject>();
        private Lobby lobby;
        private bool UpdateRequired;
        public int[,] walls;
        public bool isStarted = false;
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
            this.lobby = new Lobby(this);
            this.Calculator = new LogicFacade(this, lobby);
            this.grid = new Grid();
            walls = Walls.walls;
            UpdateRequired = false;
      
            UpdateAtInterval(50);

            GameObject gameObject = new GameObject(new Coordinates(1, 1));
            Destroyable destryable = new Destroyable(gameObject);
            Lootable lootable = new Lootable(destryable);
            Pickable pickable = new Pickable(new GameObject(new Coordinates(1, 2)));
            lootable.AddLoot(pickable);
            lootable.GetLoot();
            Console.WriteLine(lootable);
        }
        private async void UpdateAtInterval(int timeout)
        {
            await Task.Factory.StartNew(() =>
            {
                while(true)
                {
                    if(UpdateRequired)
                    UpdateGrid();

                    Thread.Sleep(timeout);   
                }
            });
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
        private async void RemoveBomb(int x, int y)
        {
            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000); // kas 3 sekundes
                grid.RemoveFromTile(x, y, 4); // 4 - bomba
                gameObjects.RemoveAt(0); // seniausia bomba
                UpdateRequired = true;
            });
        }
        private void AddGameObjsToGrid()
        {
            List<IGameObject> CurrentGameObjects = this.gameObjects;

            foreach (IGameObject obj in CurrentGameObjects)
            {
                //if (obj is Explosive)
                //{
                //    grid.AddToTile(obj.GetCords().X, obj.GetCords().Y, 4);

                //}
            }
        }
        private void AddPlayersAndBombsToGrid()
        {
            List<Player> CurrentPlayers = this.Players.ToList();
            foreach (Player player in CurrentPlayers)
            {
                //if (!(player.Bomb is null))
                //{
                //    gameObjects.Add(new Explosive(player.Bomb.GetCords().X,
                //        player.Bomb.GetCords().Y));
                //    RemoveBomb(player.Bomb.GetCords().X, player.Bomb.GetCords().Y);
                //}
                int playerX = player.xy.X;
                int playerY = player.xy.Y;
                List<int> cleanTile = new List<int>();
                cleanTile.Add(player.User.Id);
                grid.UpdateTile(playerX, playerY, cleanTile);
            }
        }
        public void StartGame()
        {
            isStarted = true;
            UpdateGrid();
      
        }
        public void UpdateGrid()
        {
            grid.Clean();
            AddPlayersAndBombsToGrid();
            AddGameObjsToGrid();

            Notify();

        }
    }
}
