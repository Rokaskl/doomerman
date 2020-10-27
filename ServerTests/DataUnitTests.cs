using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class DataUnitTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private DataUnit CreateDataUnit()
        {
            return new DataUnit();
        }

        [TestMethod]
        public void ToBytes_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dataUnit = this.CreateDataUnit();

            // Act
            var result = dataUnit.ToBytes();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dataUnit = this.CreateDataUnit();

            // Act
            var result = dataUnit.ToString();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
