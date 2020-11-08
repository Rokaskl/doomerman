using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class SpeedIncreaseTests
    {
        private SpeedIncrease speedIncrease;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            speedIncrease = new SpeedIncrease((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(TileEnumerator.TileTypeEnum.PUIncreaseSpeed, speedIncrease.type);
        }
    }
}
