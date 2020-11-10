using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Server.Tests
{
    [TestClass()]
    public class GameArenaTests
    {

        [TestMethod()]
        public void ShouldRemoveGameObject()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            Explosive bomb = new Explosive(1, 1);
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));

            gameObjectsExpected.Add(bomb);

            arena.gameObjects.Add(bomb);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObject(powerup, powerup.GetCords().X, powerup.GetCords().Y);

            CollectionAssert.AreEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldRemoveGameObjectAt_When_Pickable()
        {
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            Explosive bomb = new Explosive(1, 1);
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));

            gameObjectsExpected.Add(bomb);

            arena.gameObjects.Add(bomb);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObjectAt(powerup.GetCords().X, powerup.GetCords().Y);

            CollectionAssert.AreEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldRemoveGameObjectAt_When_Not_Pickable()
        {
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            GameObject obj = new GameObject(new Coordinates(0, 1));
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));

            gameObjectsExpected.Add(powerup);

            arena.gameObjects.Add(obj);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObjectAt(obj.GetCords().X, obj.GetCords().Y);

            CollectionAssert.AreNotEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldAddGameObject()
        {
            Explosive gameObject = new Explosive(1, 1);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            gameObjectsExpected.Add(gameObject);

            GameArena arena = new GameArena(0);
            arena.gameObjects.Add(gameObject);

            CollectionAssert.AreEqual(gameObjectsExpected, arena.gameObjects);
        }
        [TestMethod()]
        public void ShouldInitialize()
        {
            GameArena arena = new GameArena(0);
            Assert.IsNotNull(arena.Players);
            Assert.IsNotNull(arena.grid);
            Assert.IsNotNull(arena.walls);
        }
        [TestMethod()]
        public void ShouldSetWallsGrid()
        {
            GameArena arena = new GameArena(0);
            arena.AddWallsToGrid();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Assert.IsTrue(arena.grid.GetGrid()[i, j].Contains(Walls.walls[i, j]));
                }
            }
        }
        [TestMethod()]
        public void ShouldReturnOnlyDeadPlayers()
        {

            List<int> expectedDeads = new List<int>();
            GameArena arena = new GameArena(0);
            Random rn = new Random();
            for (int i = 0; i < 4; i++)
            {
                Player pl = new Player(new User(i));
                pl.Alive = Convert.ToBoolean(rn.Next(0, 2));
                arena.Players.Add(pl);
                if (!pl.Alive)
                    expectedDeads.Add(pl.User.Id);
            }
            CollectionAssert.AreEqual(expectedDeads, arena.DeadPlayers());
        }
        [TestMethod()]
        public void ShouldSetPropertiesToTrue()
        {
            GameArena arena = new GameArena(0);
            arena.StartGame();
            Assert.AreEqual(true, arena.isStarted);
            Assert.AreEqual(true, arena.UpdateRequired);
        }
        [TestMethod()]
        [DataRow(Explosive.KickDirection.Down)]
        [DataRow(Explosive.KickDirection.Left)]
        [DataRow(Explosive.KickDirection.Right)]
        [DataRow(Explosive.KickDirection.Up)]
        public void Should_ReturnTrue_When_Kick(Explosive.KickDirection dir)
        {
            GameArena arena = new GameArena(0);
            Explosive bomb = new Explosive(1, 1);
            arena.gameObjects.Add(bomb);
            Assert.IsTrue(arena.KickBomb(bomb.GetCords(), dir));

        }
        [TestMethod()]
        [DataRow(2, 1, Explosive.KickDirection.Down)]
        [DataRow(2, 3, Explosive.KickDirection.Up)]
        [DataRow(4, 3, Explosive.KickDirection.Left)]
        [DataRow(2, 7, Explosive.KickDirection.Right)]
        public void Should_ReturnFalse_When_Kick(int x, int y, Explosive.KickDirection dir)
        {
            GameArena arena = new GameArena(0);
            Explosive bomb = new Explosive(x, y);
            arena.gameObjects.Add(bomb);
            Assert.IsFalse(arena.KickBomb(bomb.GetCords(), dir));

        }

    }
}