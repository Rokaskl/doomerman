using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.FacadePattern;
using Server.GameLobby;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ServerTests.FacadePattern
{
    [TestClass]
    public class LogicFacadeTests : TestBase
    {
        private MockRepository mockRepository;

        private Mock<GameArena> mockGameArena;
        private Mock<Lobby> mockLobby;

        private Mock<ILogicFacade> mockLogicFacade;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockGameArena = this.mockRepository.Create<GameArena>(1);
            this.mockLobby = this.mockRepository.Create<Lobby>(this.mockGameArena.Object);

            this.mockLogicFacade = this.mockRepository.Create<ILogicFacade>();
        }

        private LogicFacade CreateLogicFacade()
        {
            return new LogicFacade(
                this.mockGameArena.Object,
                this.mockLobby.Object);
        }

        [TestMethod]
        public void AddCommand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var logicFacade = this.CreateLogicFacade();
            var generalCommand = new GeneralCommand();
            var arenaCommand = new ArenaCommand();

            // Act
            logicFacade.AddCommand(
                generalCommand);
            logicFacade.AddCommand(
                arenaCommand);


            // Assert
            Assert.IsNotNull(generalCommand.Receiver);
            Assert.IsNotNull(arenaCommand.Receiver);
        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            this.mockLogicFacade.Setup(x => x.FinalizeExecute());
            var logicFacade = this.CreateLogicFacade();

            

            // Act
            logicFacade.FinalizeExecute();

            // Assert
        }
    }
}
