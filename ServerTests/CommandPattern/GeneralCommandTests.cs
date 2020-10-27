using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.CommandPattern;
using System;

namespace ServerTests.CommandPattern
{
    [TestClass]
    public class GeneralCommandTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalCommand = this.CreateGeneralCommand();

            // Act
            generalCommand.Execute();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Undo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalCommand = this.CreateGeneralCommand();

            // Act
            generalCommand.Undo();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
