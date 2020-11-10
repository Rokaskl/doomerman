using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject;
using Server.MapObject.PowerUps;

namespace ServerTests.MapObject
{
    [TestClass]
    public class PickableFactoryProviderTests
    {

        [TestMethod]
        public void ShouldReturnPowerUpFactoryThanWhichIs0()
        {
            // Arrange
            int which = 0;

            // Act
            IAbstractPickableFactory result = PickableFactoryProvider.GetFactory(
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
            IAbstractPickableFactory result = PickableFactoryProvider.GetFactory(
                which);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PowerDownFactory));
        }
        [TestMethod]
        public void ShouldReturnRandomPickableObject()
        {
            // Arrange
            Coordinates cords = new Coordinates(1, 2);

            // Act
            Pickable result = PickableFactoryProvider.GetRandom(cords);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Pickable));
        }
    }
}
