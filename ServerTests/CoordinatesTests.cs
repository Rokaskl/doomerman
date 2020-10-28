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
            Assert.AreEqual(coordinates.X, (result as Coordinates).X);
            Assert.AreEqual(coordinates.Y, (result as Coordinates).Y);
            Assert.AreNotEqual(coordinates, (result as Coordinates));
        }

        [TestMethod]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var coordinates = this.CreateCoordinates();

            // Act
            var result = coordinates.ToString();

            // Assert
            Assert.AreEqual(result.GetType(), typeof(string));
        }
    }
}
