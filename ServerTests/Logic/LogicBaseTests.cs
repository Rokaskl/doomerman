using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.FacadePattern;
using Server.GameLobby;
using Server.Logic;
using System;
using System.Collections.Generic;

namespace ServerTests.Logic
{
    [TestClass]
    public class LogicBaseTests : TestBase
    {
        private MockRepository mockRepository;

        private Mock<LogicFacade> mockLogicFacade;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            var gameArena = new GameArena(1);
            this.mockLogicFacade = this.mockRepository.Create<LogicFacade>(gameArena, new Lobby(gameArena));
        }

        private LogicBase CreateLogicBase()
        {
            return new LogicBase(
                this.mockLogicFacade.Object);
        }

        [TestMethod]
        public void AddCommand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var logicBase = this.CreateLogicBase();
            logicBase.Commands = new List<Command>();
            var cmd = new ArenaCommand();

            // Act
            logicBase.AddCommand(
                cmd);

            // Assert
            Assert.AreEqual(1, logicBase.Commands.Count);
        }
    }
}
