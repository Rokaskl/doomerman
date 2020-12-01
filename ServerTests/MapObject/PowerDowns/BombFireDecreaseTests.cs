using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerDowns
{
    [TestClass]
    public class BombFireDecreaseTests : TestBase
    {
        private BombFireDecrease bombFireDecrease;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            bombFireDecrease = new BombFireDecrease();

            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUDecreaseBombRange, bombFireDecrease.type);
        }

    }
}
