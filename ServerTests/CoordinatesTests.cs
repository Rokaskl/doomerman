using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class CoordinatesTests
    {

        private Mock<Coordinates> cords;

        [TestInitialize]
        public void TestInitialize() => this.cords = new Mock<Coordinates>();

        [TestMethod()]
        public void TestConstructor()
        {
            Coordinates cords = new Coordinates(5, 6);
            Assert.AreEqual(cords.X, 5);
            Assert.AreEqual(cords.Y, 6);
        }

        [TestMethod()]
        public void Clone_StateUnderTest_ExpectedBehavior()
        {

            Coordinates cords = this.cords.Object;

            // Arrange
            Coordinates copy = (Coordinates) cords.Clone();

            // Assert rezults

            Assert.AreEqual(cords.X, copy.X);
            Assert.AreEqual(cords.Y, copy.Y);
            Assert.AreNotEqual(cords, copy);
        }

        [TestMethod()]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Coordinates cords = this.cords.Object;

            // Act
            var result = cords.ToString();

            // Assert
            Assert.IsTrue(result.Length > 12);
        }
    }
}
