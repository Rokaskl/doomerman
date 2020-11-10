using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.GameLobby;
using Server.Logic;
using System;

namespace ServerTests.Logic
{
    [TestClass]
    public class GeneralLogicTests : TestBase
    {
        private MockRepository mockRepository;

        private Mock<Lobby> mockLobby;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLobby = this.mockRepository.Create<Lobby>(new GameArena(1));
        }

        private GeneralLogic CreateGeneralLogic()
        {
            return new GeneralLogic(
                this.mockLobby.Object);
        }

        [TestMethod]
        public void Action_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalLogic = this.CreateGeneralLogic();
            var generalCommand = new GeneralCommand();
            generalCommand.Author = new Player(User);


            mockLobby.Setup(x => x.AddPlayer(generalCommand.Author)).Returns(true);
            mockLobby.Setup(x => x.RemovePlayer(generalCommand.Author));
            mockLobby.Setup(x => x.PlayerReady(generalCommand)).Returns(true);
            mockLobby.Setup(x => x.GetReadyCommand(generalCommand.Author)).Returns(generalCommand);

            // Act
            generalCommand.Cmds.Add(GeneralCommandEnum.JoinLobby);
            generalLogic.Action(
                generalCommand);
            generalCommand.Cmds.Remove(GeneralCommandEnum.JoinLobby);

            generalCommand.Cmds.Add(GeneralCommandEnum.LeaveLobby);
            generalLogic.Action(
                generalCommand);
            generalCommand.Cmds.Remove(GeneralCommandEnum.LeaveLobby);

            generalCommand.Cmds.Add(GeneralCommandEnum.NotReady);
            generalLogic.Action(
                generalCommand);
            generalCommand.Cmds.Remove(GeneralCommandEnum.NotReady);

            generalCommand.Cmds.Add(GeneralCommandEnum.Ready);
            generalLogic.Action(
                generalCommand);
            generalCommand.Cmds.Remove(GeneralCommandEnum.Ready);

            // Assert
            mockLobby.Verify(x => x.AddPlayer(generalCommand.Author), Times.Once);
            mockLobby.Verify(x => x.RemovePlayer(generalCommand.Author), Times.Once);
            mockLobby.Verify(x => x.PlayerReady(generalCommand), Times.Once);
            mockLobby.Verify(x => x.GetReadyCommand(generalCommand.Author), Times.Once);

        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalLogic = this.CreateGeneralLogic();
            mockLobby.Object.isStarting = true;
            mockLobby.Setup(x => x.SendInfo());
            // Act
            generalLogic.FinalizeExecute();

            // Assert
            mockLobby.Verify(x => x.SendInfo(), Times.Once);
        }
    }
}
