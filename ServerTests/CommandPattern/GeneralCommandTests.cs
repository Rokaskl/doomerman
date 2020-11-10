using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.GameLobby;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ServerTests.CommandPattern
{
    [TestClass]
    public class GeneralCommandTests : TestBase
    {
        private MockRepository mockRepository;

        private Mock<IReceiver> Receiver;

        private Mock<Lobby> Lobby;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.Receiver = this.mockRepository.Create<IReceiver>();

            this.Lobby = this.mockRepository.Create<Lobby>(new GameArena(1));
        }

        private GeneralCommand CreateGeneralCommand()
        {
            return new GeneralCommand();
        }

        [TestMethod]
        public void AddSubCommand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalCommand = this.CreateGeneralCommand();
            int subCommand = 0;

            // Act
            generalCommand.AddSubCommand(
                subCommand);

            // Assert
            Assert.AreEqual(generalCommand.Cmds.Count, 1);
        }

        [TestMethod]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalCommand = this.CreateGeneralCommand();
            var arena = new GameArena(1);
            generalCommand.Receiver = this.Receiver.Object;
            generalCommand.Author = new Player(User);
            this.Receiver.Setup(x => x.Action(It.IsAny<GeneralCommand>()));

            // Act
            generalCommand.Execute();

            // Assert
            this.Receiver.Verify(x => x.Action(generalCommand), Times.Once);
        }

        [TestMethod]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalCommand = this.CreateGeneralCommand();

            var player = new Player(User);

            //Add ready command
            generalCommand.AddSubCommand(2);
            generalCommand.Author = player;
            player.PlayerLobby = Lobby.Object;

            Lobby.Setup(x => x.PlayerNotReady(player));

            // Act
            // Undo ready command
            generalCommand.Undo();//Author.PlayerLobby.PlayerNotReady(Author);2

            // Assert
            Lobby.Verify(x => x.PlayerNotReady(player), Times.Once);
        }
    }
}
