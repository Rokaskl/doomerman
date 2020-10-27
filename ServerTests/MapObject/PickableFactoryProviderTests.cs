using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject;
using System;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableFactoryProviderTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PickableFactoryProvider CreateProvider()
        {
            return new PickableFactoryProvider();
        }

        [TestMethod]
        public void GetFactory_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var provider = this.CreateProvider();
            int which = 0;

            // Act
            var result = PickableFactoryProvider.GetFactory(
                which);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetRandom_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var provider = this.CreateProvider();
            Coordinates xy = null;

            // Act
            var result = provider.GetRandom(
                xy);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
