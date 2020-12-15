using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject;
using Server.MapObject.PowerUps;
using ServerTests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Server.Tests
{
    [TestClass()]
    public class GameArenaTests : TestBase
    {

        [TestMethod()]
        public void ShouldRemoveGameObject()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            Explosive bomb = new Explosive(1, 1);
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));
            // Act
            gameObjectsExpected.Add(bomb);

            arena.gameObjects.Add(bomb);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObject(powerup, powerup.GetCords().X, powerup.GetCords().Y);
            //Assert
            CollectionAssert.AreEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldRemoveGameObjectAt_When_Pickable()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            Explosive bomb = new Explosive(1, 1);
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));
            // Act
            gameObjectsExpected.Add(bomb);

            arena.gameObjects.Add(bomb);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObjectAt(powerup.GetCords().X, powerup.GetCords().Y);
            //Assert
            CollectionAssert.AreEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldRemoveGameObjectAt_When_Not_Pickable()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            GameObject obj = new GameObject(new Coordinates(0, 1));
            Pickable powerup = new BombFireDecrease(new GameObject(new Coordinates(2, 2)));

            // Act
            gameObjectsExpected.Add(powerup);
            arena.gameObjects.Add(obj);
            arena.gameObjects.Add(powerup);

            arena.RemoveGameObjectAt(obj.GetCords().X, obj.GetCords().Y);
            //Assert
            CollectionAssert.AreNotEqual(arena.gameObjects, gameObjectsExpected);
        }
        [TestMethod()]
        public void ShouldAddGameObject()
        {
            //Arrange
            Explosive gameObject = new Explosive(1, 1);
            List<IGameObject> gameObjectsExpected = new List<IGameObject>();
            gameObjectsExpected.Add(gameObject);
            // Act
            GameArena arena = new GameArena(0);
            arena.gameObjects.Add(gameObject);
            //Assert
            CollectionAssert.AreEqual(gameObjectsExpected, arena.gameObjects);
        }
        [TestMethod()]
        public void ShouldInitialize()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            //Assert
            Assert.IsNotNull(arena.Players);
            Assert.IsNotNull(arena.grid);
            Assert.IsNotNull(arena.walls);
        }
        [TestMethod()]
        public void ShouldSetWallsGrid()
        {
            //Arrange
            GameArena arena = new GameArena(0);
            // Act
            arena.UpdateGrid();
            //Assert
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (arena.grid.GetGrid()[i, j].Count > 0)
                        Assert.IsTrue(arena.grid.GetGrid()[i, j].Contains(Walls.walls[i, j]));
                }
            }
        }
        [TestMethod()]
        public void ShouldReturnOnlyDeadPlayers()
        {
            //Arrange
            List<int> expectedDeads = new List<int>();
            GameArena arena = new GameArena(0);

            for (int i = 0; i < 4; i++)
            {
                Player pl = new Player(new User(i));
                pl.Alive = Convert.ToBoolean(i % 2);
                arena.Players.Add(pl);
                // Act
                if (!pl.Alive)
                    expectedDeads.Add(pl.User.Id);
            }
            //Assert
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
            //Arrange
            GameArena arena = new GameArena(0);
            Explosive bomb = new Explosive(1, 1);
            // Act
            arena.gameObjects.Add(bomb);
            //Assert
            Assert.IsTrue(arena.KickBomb(bomb.GetCords(), dir));

        }
        [TestMethod()]
        [DataRow(2, 1, Explosive.KickDirection.Down)]
        [DataRow(2, 3, Explosive.KickDirection.Up)]
        [DataRow(4, 3, Explosive.KickDirection.Left)]
        [DataRow(2, 7, Explosive.KickDirection.Right)]
        public void Should_ReturnFalse_When_Kick(int x, int y, Explosive.KickDirection dir)
        {
            //Arrange
            GameArena arena = new GameArena(0);
            Explosive bomb = new Explosive(x, y);
            // Act
            arena.gameObjects.Add(bomb);
            //Assert
            Assert.IsFalse(arena.KickBomb(bomb.GetCords(), dir));

        }

    }
}