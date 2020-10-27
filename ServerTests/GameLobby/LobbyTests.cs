using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.GameLobby;
using System;

namespace ServerTests.GameLobby
{
    [TestClass]
    public class LobbyTests
    {
        private MockRepository mockRepository;

        private Mock<GameArena> mockGameArena;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameArena = this.mockRepository.Create<GameArena>();
        }

        private Lobby CreateLobby()
        {
            return new Lobby(
                this.mockGameArena.Object);
        }

        [TestMethod]
        public void AddPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();
            Player player = null;

            // Act
            var result = lobby.AddPlayer(
                player);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RemovePlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();
            Player player = null;

            // Act
            lobby.RemovePlayer(
                player);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PlayerReady_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();
            GeneralCommand command = null;

            // Act
            var result = lobby.PlayerReady(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PlayerNotReady_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();
            Player player = null;

            // Act
            lobby.PlayerNotReady(
                player);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetReadyCommand_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();
            Player player = null;

            // Act
            var result = lobby.GetReadyCommand(
                player);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SendInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lobby = this.CreateLobby();

            // Act
            lobby.SendInfo();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
