using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.Logic;
using System;

namespace ServerTests.Logic
{
    [TestClass]
    public class ArenaLogicTests
    {
        private MockRepository mockRepository;

        private Mock<GameArena> mockGameArena;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameArena = this.mockRepository.Create<GameArena>();
        }

        private ArenaLogic CreateArenaLogic()
        {
            return new ArenaLogic(
                this.mockGameArena.Object);
        }

        [TestMethod]
        public void Action_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaLogic = this.CreateArenaLogic();
            Command command = null;

            // Act
            arenaLogic.Action(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaLogic = this.CreateArenaLogic();

            // Act
            arenaLogic.FinalizeExecute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
