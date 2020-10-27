using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class CoordinatesTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Coordinates CreateCoordinates()
        {
            return new Coordinates();
        }

        [TestMethod]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var coordinates = this.CreateCoordinates();

            // Act
            var result = coordinates.Clone();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var coordinates = this.CreateCoordinates();

            // Act
            var result = coordinates.ToString();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
