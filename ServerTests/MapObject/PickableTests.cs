using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableTests
    {
        private Mock<Coordinates> cords;

        [TestInitialize]
        public void TestInitialize() => this.cords = new Mock<Coordinates>();
        private Pickable CreatePickable() => new Pickable();
        private Coordinates CreateNewCoordinates() => new Mock<Coordinates>().Object;

        [TestMethod]

        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            Pickable pickable = this.CreatePickable();
            Coordinates xy = CreateNewCoordinates();
            // Act
            pickable.SetCords(xy);

            // Assert
            Assert.AreEqual(pickable.GetCords(), xy);
        }


        [TestMethod]
        public void ShouldReturnLootableTag()
        {
            // Arrange
            Pickable pickable = this.CreatePickable();

            // Act
            System.Collections.Generic.List<string> result = pickable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Pickable");
        }

    }
}
