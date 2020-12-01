using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class DestroyableTests : TestBase
    {
        private Mock<Coordinates> cords;

        [TestInitialize]
        public void TestInitialize() => this.cords = new Mock<Coordinates>();
        private Coordinates CreateNewCoordinates() => new Mock<Coordinates>().Object;

        private Destroyable CreateDestroyable() => new Destroyable(new GameObject(this.cords.Object));
        [TestMethod]

        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            Destroyable destroyable = this.CreateDestroyable();
            Coordinates xy = CreateNewCoordinates();
            // Act
            destroyable.SetCords(xy);

            // Assert
            Assert.AreEqual(destroyable.GetCords(), xy);
        }
        [TestMethod]
        public void ShouldReturnDestroyableTag()
        {
            // Arrange
            Destroyable destroyable = this.CreateDestroyable();

            // Act
            List<string> result = destroyable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Destroyable");
        }
    }
}
