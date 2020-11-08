using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class DestroyableTests
    {
        private MockRepository mockRepository;
        private Coordinates cords;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this.cords = new Coordinates(0, 0);
        }

        private Destroyable CreateDestroyable()
        {
            return new Destroyable(new GameObject(cords));
        }

        [TestMethod]
        public void ShouldReturnDestroyableTag()
        {
            // Arrange
            var destroyable = this.CreateDestroyable();

            // Act
            var result = destroyable.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Destroyable");
        }
    }
}
