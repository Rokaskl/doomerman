using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject;
using Server.MapObject.PowerUps;
using System;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableFactoryProviderTests
    {


        private PickableFactoryProvider CreateProvider()
        {
            return new PickableFactoryProvider();
        }

        [TestMethod]
        public void ShouldReturnPowerUpFactoryThanWhichIs0()
        {
            // Arrange
            int which = 0;

            // Act
            var result = PickableFactoryProvider.GetFactory(
                which);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PowerUpFactory));
        }

        [TestMethod]
        public void ShouldReturnPowerDownFactoryThanWhichIs1()
        {
            // Arrange
            int which = 1;

            // Act
            var result = PickableFactoryProvider.GetFactory(
                which);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PowerDownFactory));
        }
        [TestMethod]
        public void ShouldReturnRandomPickableObject()
        {
            // Arrange
            Coordinates cords = new Coordinates(1,2);

            // Act
            var result = PickableFactoryProvider.GetRandom(cords);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Pickable));
        }
    }
}
