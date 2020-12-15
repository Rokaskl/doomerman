using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject.PowerDowns;
using Server.MapObject.PowerUps;
using System;

namespace ServerTests.MapObject.PowerDowns
{
    [TestClass]
    public class PowerDownFactoryTests : TestBase
    {
        private PowerDownFactory powerDownFactory;

        [TestMethod]
        [DataRow(0, typeof(BombFireDecrease))]
        [DataRow(1, typeof(BombLimitDecrease))]
        [DataRow(2, typeof(AutoPlacer))]
        public void ShouldBeCorrespondingTypeWhenBuilt(int which, Type type)
        {
            powerDownFactory = new PowerDownFactory();
            var obj = powerDownFactory.Build(which, new Coordinates());

            Assert.IsInstanceOfType(obj, type);
        }
    }
}
