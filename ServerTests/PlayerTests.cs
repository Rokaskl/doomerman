using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using System;
using System.Collections.Generic;

namespace ServerTests
{
    [TestClass]
    public class PlayerTests
    {
        private MockRepository mockRepository;

        private Mock<User> mockUser;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUser = this.mockRepository.Create<User>();
        }

        private Player CreatePlayer()
        {
            return new Player(
                this.mockUser.Object);
        }

        [TestMethod]
        public void CanMove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            ArenaCommandEnum cmd = default(global::Server.CommandPattern.ArenaCommandEnum);
            List<int>[,] walls = null;

            // Act
            var result = player.CanMove(
                cmd,
                walls);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void CanDropBomb_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            var result = player.CanDropBomb();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DropBomb_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.DropBomb();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ChangeStrategy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            IMoveStrategy strategy = null;

            // Act
            player.ChangeStrategy(
                strategy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AddPowerUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            Pickable item = null;

            // Act
            player.AddPowerUp(
                item);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void MoveUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.MoveUp();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void MoveDown_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.MoveDown();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void MoveRight_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.MoveRight();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void MoveLeft_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.MoveLeft();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            Grid grid = null;

            // Act
            //player.Update(grid);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void IncBombLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.IncBombLimit();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DecBombLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.DecBombLimit();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
