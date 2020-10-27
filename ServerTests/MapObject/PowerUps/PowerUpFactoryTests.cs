using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject.PowerUps;
using System;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class PowerUpFactoryTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PowerUpFactory CreateFactory()
        {
            return new PowerUpFactory();
        }

        [TestMethod]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            int which = 0;
            Coordinates xy = null;

            // Act
            var result = factory.Build(
                which,
                xy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetRandom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            Coordinates cords = null;

            // Act
            var result = factory.GetRandom(
                cords);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
