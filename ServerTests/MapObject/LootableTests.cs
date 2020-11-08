using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class LootableTests
    {
        private MockRepository mockRepository;
        private Coordinates cords;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.cords =  new Coordinates();
        }

        private Lootable CreateLootable()
        {
            return new Lootable(new GameObject(cords));
        }
        [TestMethod]

        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            var lootable = this.CreateLootable();
            Coordinates xy = null;

            // Act
            lootable.SetCords(
                xy);

            // Assert
            Assert.AreEqual(lootable.GetCords(), xy);

        }

        [TestMethod]
        public void ShouldAddAndReturnLoot()
        {
            // Arrange
            var lootable = this.CreateLootable();
            Pickable pickable = null;

            // Act
            lootable.AddLoot(
                pickable);

            // Assert
            Assert.AreEqual(lootable.GetLoot(), pickable);
        }

        [TestMethod]
        public void ShouldReturnLootableTag()
        {
            // Arrange
            var lootable = this.CreateLootable();

            // Act
            var result = lootable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Lootable");
        }

    }
}
