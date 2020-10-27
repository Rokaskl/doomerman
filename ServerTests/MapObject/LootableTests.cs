using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests.MapObject
{
    [TestClass]
    public class LootableTests
    {
        private MockRepository mockRepository;

        private Mock<IGameObject> mockGameObject;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameObject = this.mockRepository.Create<IGameObject>();
        }

        private Lootable CreateLootable()
        {
            return new Lootable(
                this.mockGameObject.Object);
        }

        [TestMethod]
        public void GetTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lootable = this.CreateLootable();

            // Act
            var result = lootable.GetTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PrintTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lootable = this.CreateLootable();

            // Act
            lootable.PrintTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lootable = this.CreateLootable();

            // Act
            var result = lootable.GetCords();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
