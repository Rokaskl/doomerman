using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;

namespace ServerTests.MapObject
{
    [TestClass]
    public class ExplosiveTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Explosive CreateExplosive()
        {
            return new Explosive();
        }

        [TestMethod]
        public void IncRadius_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            explosive.IncRadius();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void DecRadius_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            explosive.DecRadius();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            var result = explosive.GetTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PrintTags_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            explosive.PrintTags();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            var result = explosive.GetCords();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SetCords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosive = this.CreateExplosive();
            Coordinates xy = null;

            // Act
            explosive.SetCords(
                xy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
