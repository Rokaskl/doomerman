using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class BombLimitIncreaseTests : TestBase
    {
        private BombLimitIncrease bombLimitIncrease;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            bombLimitIncrease = new BombLimitIncrease((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUIncreaseBombLimit, bombLimitIncrease.type);
        }
    }
}
