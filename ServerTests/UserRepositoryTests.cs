using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;
using System.Linq;

namespace ServerTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private MockRepository mockRepository;
        private UserRepository userRepository { get; } = new UserRepository();
        private User user { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestMethod]
        public void AddUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.userRepository;
            this.user = new User(1, "test");

            // Act
            var result = userRepository.AddUser(
                this.user);

            // Assert
            Assert.IsNotNull(userRepository.Users.FirstOrDefault(x => x == this.user));
        }

        [TestMethod]
        public void RemoveUser_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.userRepository;

            // Act
            userRepository.RemoveUser(
                this.user);

            // Assert
            Assert.IsTrue(!userRepository.Users.Any(x => x == this.user));
        }

        [TestMethod]
        public void Exists_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userRepository = this.userRepository;
            var anotherUser = new User(2, "test2");

            // Act
            var _ = userRepository.AddUser(
                anotherUser);

            var result = userRepository.Exists(
                anotherUser);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
