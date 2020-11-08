using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableTests
    {
        private MockRepository mockRepository;
        private Coordinates cords;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.cords = new Coordinates();
        }

        private Pickable CreatePickable()
        {
            return new Pickable();
        }

        [TestMethod]

        public void ShouldSetAndGetCoordinates()
        {
            // Arrange
            var pickable = this.CreatePickable();
            Coordinates xy = null;

            // Act
            pickable.SetCords(
                xy);

            // Assert
            Assert.AreEqual(pickable.GetCords(), xy);
        }


        [TestMethod]
        public void ShouldReturnLootableTag()
        {
            // Arrange
            var pickable = this.CreatePickable();

            // Act
            var result = pickable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Pickable");
        }

    }
}
