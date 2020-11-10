using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.FacadePattern;
using Server.Logic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ServerTests.CommandPattern
{
    [TestClass]
    public class ArenaCommandTests : TestBase
    {
        private MockRepository mockRepository;

        private Mock<IReceiver> Receiver;

        private Mock<Command> Command;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.Receiver = this.mockRepository.Create<IReceiver>();

            this.Command = this.mockRepository.Create<Command>();

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
            var arena = new GameArena(1);
            arenaCommand.Receiver = this.Receiver.Object;
            arenaCommand.Author = new Player(new User(1, "user"));

            this.Receiver.Setup(x => x.Action(It.IsAny<ArenaCommand>()));

            // Act
            arenaCommand.Execute();

            this.Receiver.Verify(x => x.Action(arenaCommand), Times.Once);
        }

        [TestMethod]
        public void GetCmds_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommand = this.CreateArenaCommand();
            arenaCommand.AddSubCommand(1);
            arenaCommand.AddSubCommand(0);
            // Act
            var result = arenaCommand.GetCmds();

            // Assert
            Assert.AreEqual(result.Count, 2);
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
            Assert.AreEqual(arenaCommand.Cmds.Count, 1);
        }

        [TestMethod]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var arenaCommandMock = this.mockRepository.Create<ArenaCommand>();
            arenaCommandMock.Setup(x => x.Undo());

            // Act
            //Currently has no other logic
            arenaCommandMock.Object.Undo();

            // Assert
            arenaCommandMock.Verify(x => x.Undo(), Times.Once);
        }
    }
}
