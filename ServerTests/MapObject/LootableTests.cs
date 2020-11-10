using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class LootableTests
    {
        private Mock<Coordinates> cords;
        private Mock<Pickable> pickable;
        [TestInitialize]
        public void TestInitialize()
        {
            this.cords = new Mock<Coordinates>();
            this.pickable = new Mock<Pickable>();
        }

        private Coordinates CreateNewCoordinates() => new Mock<Coordinates>().Object;
        private Lootable CreateLootable() => new Lootable(new GameObject(this.cords.Object));
        [TestMethod]

        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            Lootable lootable = this.CreateLootable();
            Coordinates xy = this.CreateNewCoordinates();

            // Act
            lootable.SetCords(xy);

            // Assert
            Assert.AreEqual(lootable.GetCords(), xy);

        }

        [TestMethod]
        public void ShouldSetLoot()
        {
            // Arrange
            Lootable lootable = this.CreateLootable();


            // Act
            lootable.AddLoot(this.pickable.Object);

            // Assert
            Assert.AreEqual(lootable.GetLoot(), this.pickable.Object);
        }

        [TestMethod]
        public void ShouldReturnLootableTag()
        {
            // Arrange
            Lootable lootable = this.CreateLootable();

            // Act
            List<string> result = lootable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Lootable");
        }

    }
}
