using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.CommandPattern;
using System;

namespace ServerTests.CommandPattern
{
    [TestClass]
    public class ArenaCommandTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ArenaCommand CreateArenaCommand()
        {
            return new ArenaCommand();
        }

        [TestMethod]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommand = this.CreateArenaCommand();

            // Act
            arenaCommand.Execute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCmds_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommand = this.CreateArenaCommand();

            // Act
            var result = arenaCommand.GetCmds();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AddSubCommand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommand = this.CreateArenaCommand();
            int subCommand = 0;

            // Act
            arenaCommand.AddSubCommand(
                subCommand);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommand = this.CreateArenaCommand();

            // Act
            arenaCommand.Undo();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
