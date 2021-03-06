using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.GameLobby;
using System;
using Moq;
using NUnit.Framework.Constraints;

namespace ServerTests.GameLobby
{
    [TestClass]
    public class LobbyTests : TestBase
    {
        private Lobby lobby;
        private Mock<Sender> senderMock;
        
        [TestInitialize]
        public void Initialize()
        {
            senderMock = new Mock<Sender>(User);
        }

        [TestMethod]
        public void ShouldFailWhenAddingPlayerToFullLobby()
        {
            lobby = new Lobby(new GameArena(0));

            Player player1 = new Player(new User());
            Player player2 = new Player(new User());
            Player player3 = new Player(new User());
            Player player4 = new Player(new User());
            Player player5 = new Player(new User());

            lobby.AddPlayer(player1);
            lobby.AddPlayer(player2);
            lobby.AddPlayer(player3);
            lobby.AddPlayer(player4);

            Assert.IsFalse(lobby.AddPlayer(player5));

        }
        [TestMethod]
        public void ShouldFailWhenAddingSamePlayer()
        {
            lobby = new Lobby(new GameArena(0));

            Player player = new Player(new User());

            lobby.AddPlayer(player);

            Assert.IsFalse(lobby.AddPlayer(player));

        }

        [TestMethod]
        public void ShouldSucceedWhenAddingPlayerToNotFullLobby()
        {
            lobby = new Lobby(new GameArena(0));

            Player player = new Player(new User());

            Assert.IsTrue(lobby.AddPlayer(player));
        }

        [TestMethod]
        public void ShouldFailWhenSameReadyCommand()
        {
            lobby = new Lobby(new GameArena(0));

            GeneralCommand command = new GeneralCommand();
            command.Author = new Player(new User());

            lobby.PlayerReady(command);

            Assert.IsFalse(lobby.PlayerReady(command));
        }

        [TestMethod]
        public void ShouldFailWhenContainsPlayerAfterRemoving()
        {
            lobby = new Lobby(new GameArena(0));

            Player player = new Player(new User());

            lobby.AddPlayer(player);
            lobby.RemovePlayer(player);
        }

        [TestMethod]
        public void ShouldCallSendWhenThereArePlayersInLobby()
        {
            lobby = new Lobby(new GameArena(0));

            senderMock.Setup(x => x.Send(It.IsAny<int>(), It.IsAny<string>()));

            Player player = new Player(User);
            player.sender = senderMock.Object;

            lobby.AddPlayer(player);
            lobby.SendInfo();

            senderMock.Verify(x => x.Send(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
