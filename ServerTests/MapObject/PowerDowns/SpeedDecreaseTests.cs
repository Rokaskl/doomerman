using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerDowns
{
    [TestClass]
    public class SpeedDecreaseTests
    {
        private SpeedDecrease speedDecrease;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            speedDecrease = new SpeedDecrease((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(TileEnumerator.TileTypeEnum.PUDecreaseSpeed, speedDecrease.type);
        }

    }
}
