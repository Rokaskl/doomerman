using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableTests
    {
        private MockRepository mockRepository;

        private Mock<IGameObject> mockGameObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameObject = this.mockRepository.Create<IGameObject>();
        }

        private Pickable CreatePickable()
        {
            return new Pickable(
                this.mockGameObject.Object);
        }

        [TestMethod]
        public void GetTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pickable = this.CreatePickable();

            // Act
            var result = pickable.GetTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PrintTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pickable = this.CreatePickable();

            // Act
            pickable.PrintTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pickable = this.CreatePickable();

            // Act
            var result = pickable.GetCords();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
