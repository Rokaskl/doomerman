using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject;

namespace ServerTests
{
    [TestClass]
    public class WallsAdapterTests
    {
        private MockRepository mockRepository;

        private Mock<Walls> mockWalls;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockWalls = this.mockRepository.Create<Walls>();
        }

        private WallsAdapter CreateWallsAdapter()
        {
            return new WallsAdapter(
                this.mockWalls.Object);
        }

        [TestMethod]
        public void GetGrid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var wallsAdapter = this.CreateWallsAdapter();

            // Act
            var result = wallsAdapter.GetGrid();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
