using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;

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
        public void GetTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.GetTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PrintTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            gameObject.PrintTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.GetCords();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            Coordinates xy = null;

            // Act
            gameObject.SetCords(
                xy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AddLoot_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            Pickable pickable = null;

            // Act
            gameObject.AddLoot(
                pickable);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetLoot_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.GetLoot();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
