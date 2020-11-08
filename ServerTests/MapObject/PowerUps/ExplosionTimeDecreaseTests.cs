using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class ExplosionTimeDecreaseTests
    {
        private ExplosionTimeDecrease explosionTimeDecrease;
        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            explosionTimeDecrease = new ExplosionTimeDecrease((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime, explosionTimeDecrease.type);
        }


    }
}
