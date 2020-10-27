using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.CommandPattern;
using Server.GameLobby;
using Server.Logic;
using System;

namespace ServerTests.Logic
{
    [TestClass]
    public class GeneralLogicTests
    {
        private MockRepository mockRepository;

        private Mock<Lobby> mockLobby;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLobby = this.mockRepository.Create<Lobby>();
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
            Command command = null;

            // Act
            generalLogic.Action(
                command);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalLogic = this.CreateGeneralLogic();

            // Act
            generalLogic.FinalizeExecute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
