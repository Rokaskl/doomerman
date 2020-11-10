using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class CoordinatesTests
    {

        [TestMethod()]
        public void TestConstructor()
        {
            Coordinates cords = new Coordinates(5, 6);
            Assert.AreEqual(cords.X, 5);
            Assert.AreEqual(cords.Y, 6);
        }

        [TestMethod()]
        public void ShouldSetCorrectProperties()
        {

            Coordinates cords = new Coordinates(5, 6);

            // Arrange
            Coordinates copy = (Coordinates) cords.Clone();

            // Assert rezults

            Assert.AreEqual(cords.X, copy.X);
            Assert.AreEqual(cords.Y, copy.Y);
            Assert.AreNotEqual(cords, copy);
        }

        [TestMethod()]
        public void ShouldSendCorrectLength()
        {
            // Arrange
            Coordinates cords = new Coordinates(5, 6);

            // Act
            var result = cords.ToString();

            // Assert
            Assert.IsTrue(result.Length > 12);
        }
    }
}
