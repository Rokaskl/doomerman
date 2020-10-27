using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;
using System.Collections.Generic;

namespace ServerTests.MapObject
{
    [TestClass]
    public class GameObjectTests
    {
        private MockRepository mockRepository;

        private Mock<Coordinates> mockCoordinates;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockCoordinates = this.mockRepository.Create<Coordinates>();
        }

        private GameObject CreateGameObject()
        {
            return new GameObject(
                this.mockCoordinates.Object);
        }

        [TestMethod]
        public void ShouldGetEmptyTagsThenCreated()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.GetTags();

            // Assert
            CollectionAssert.AreEqual(result, new List<string>());
           
        }
        [TestMethod]
        public void ShouldReturnCordsObj()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.GetCords();

            // Assert
            Assert.AreEqual(result, this.mockCoordinates.Object);
        }

        [TestMethod]
        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            Coordinates xy = null;

            // Act
            gameObject.SetCords(
                xy);

            // Assert
            Assert.AreEqual(gameObject.GetCords(), xy);
           
        }

        [TestMethod]
        public void ShouldAddAndReturnLoot()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            Pickable pickable = null;

            // Act
            gameObject.AddLoot(
                pickable);

            // Assert
            Assert.AreEqual(gameObject.GetLoot(), pickable);
        }


    }
}
