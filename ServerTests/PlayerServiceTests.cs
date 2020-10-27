using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.FacadePattern;
using System;
using System.Threading.Tasks;

namespace ServerTests
{
    [TestClass]
    public class PlayerServiceTests
    {
        private MockRepository mockRepository;

        private Mock<Player> mockPlayer;
        private Mock<LogicFacade> mockLogicFacade;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPlayer = this.mockRepository.Create<Player>();
            this.mockLogicFacade = this.mockRepository.Create<LogicFacade>();
        }

        private PlayerService CreateService()
        {
            return new PlayerService(
                this.mockPlayer.Object,
                this.mockLogicFacade.Object);
        }

        [TestMethod]
        public async Task ListenPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Player player = null;
            LogicFacade logic = null;

            // Act
            await service.ListenPlayer(
                player,
                logic);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
