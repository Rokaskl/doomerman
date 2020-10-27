using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class DestroyableTests
    {
        private MockRepository mockRepository;

        private Mock<IGameObject> mockGameObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameObject = this.mockRepository.Create<IGameObject>();
        }

        private Destroyable CreateDestroyable()
        {
            return new Destroyable(
                this.mockGameObject.Object);
        }

        [TestMethod]
        public void GetTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var destroyable = this.CreateDestroyable();

            // Act
            var result = destroyable.GetTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PrintTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var destroyable = this.CreateDestroyable();

            // Act
            destroyable.PrintTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var destroyable = this.CreateDestroyable();

            // Act
            var result = destroyable.GetCords();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
