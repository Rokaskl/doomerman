using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.CommandPattern;
using Server.FacadePattern;
using Server.Logic;
using System;

namespace ServerTests.Logic
{
    [TestClass]
    public class LogicBaseTests
    {
        private MockRepository mockRepository;

        private Mock<LogicFacade> mockLogicFacade;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogicFacade = this.mockRepository.Create<LogicFacade>();
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
            Command cmd = null;

            // Act
            logicBase.AddCommand(
                cmd);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void FinalizeExecute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var logicBase = this.CreateLogicBase();

            // Act
            logicBase.FinalizeExecute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
