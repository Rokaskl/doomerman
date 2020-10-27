using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System.Threading.Tasks;

namespace ServerTests
{
    [TestClass]
    public class ListenerTests
    {
        private MockRepository mockRepository;

        private Mock<GameArena> mockGameArena;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameArena = this.mockRepository.Create<GameArena>();
        }

        private Listener CreateListener()
        {
            return new Listener(
                "127.0.0.1",
                13000,
                this.mockGameArena.Object);
        }

        [TestMethod]
        public async Task StartListener_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var listener = this.CreateListener();

            // Act
            await listener.StartListener();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
