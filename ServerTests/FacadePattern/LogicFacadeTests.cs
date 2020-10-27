using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.FacadePattern;
using Server.GameLobby;
using System;

namespace ServerTests.FacadePattern
{
    [TestClass]
    public class LogicFacadeTests
    {
        private MockRepository mockRepository;

        private Mock<GameArena> mockGameArena;
        private Mock<Lobby> mockLobby;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameArena = this.mockRepository.Create<GameArena>();
            this.mockLobby = this.mockRepository.Create<Lobby>();
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
            Command command = null;

            // Act
            logicFacade.AddCommand(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var logicFacade = this.CreateLogicFacade();

            // Act
            logicFacade.FinalizeExecute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
