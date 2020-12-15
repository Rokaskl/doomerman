using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerDowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerDowns
{
    [TestClass]
    public class BombLimitDecreaseTests : TestBase
    {
        private BombLimitDecrease bombLimitDecrease;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            bombLimitDecrease = new BombLimitDecrease(new Server.GameObject(new Server.Coordinates()));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUDecreaseBombLimit, bombLimitDecrease.type);
        }

    }
}
