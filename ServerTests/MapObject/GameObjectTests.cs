using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class GameObjectTests
    {
        private Mock<Coordinates> cords;

        [TestInitialize]
        public void TestInitialize() => this.cords = new Mock<Coordinates>();

        private Coordinates CreateNewCoordinates() => new Mock<Coordinates>().Object;

        private GameObject CreateGameObject() => new GameObject(
                this.cords.Object);

        [TestMethod]
        public void ShouldGetEmptyTagsThenCreated()
        {
            // Arrange
            GameObject gameObject = this.CreateGameObject();

            // Act
            List<string> result = gameObject.GetTags();

            // Assert
            CollectionAssert.AreEqual(result, new List<string>());

        }

        [TestMethod]
        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            GameObject gameObject = this.CreateGameObject();
            Coordinates xy = CreateNewCoordinates();

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
            GameObject gameObject = this.CreateGameObject();
            Pickable pickable = null;

            // Act
            gameObject.AddLoot(
                pickable);

            // Assert
            Assert.AreEqual(gameObject.GetLoot(), pickable);
        }


    }
}
