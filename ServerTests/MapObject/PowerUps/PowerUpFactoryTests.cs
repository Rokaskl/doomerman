using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.MapObject.PowerUps;
using System;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class PowerUpFactoryTests : TestBase
    {
        private PowerUpFactory factory;

        [TestMethod]
        [DataRow(0, typeof(BombKick))]
        [DataRow(1, typeof(BombLimitIncrease))]
        [DataRow(2, typeof(BombFireIncrease))]
        [DataRow(3, typeof(TemporaryJump))]
        [DataRow(4, typeof(TemporarySwim))]
        public void ShouldCorrespondingTypeWhenBuilt(int which, Type type)
        {
            factory = new PowerUpFactory();
            var obj = factory.Build(which, new Coordinates());

            Assert.IsInstanceOfType(obj, type);
        }
    }
}
