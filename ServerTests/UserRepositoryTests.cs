using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;

namespace ServerTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private UserRepository CreateUserRepository()
        {
            return new UserRepository();
        }

        [TestMethod]
        public void AddUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.CreateUserRepository();
            User user = null;

            // Act
            var result = userRepository.AddUser(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RemoveUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.CreateUserRepository();
            User user = null;

            // Act
            userRepository.RemoveUser(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Exists_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.CreateUserRepository();
            User user = null;

            // Act
            var result = userRepository.Exists(
                user);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
