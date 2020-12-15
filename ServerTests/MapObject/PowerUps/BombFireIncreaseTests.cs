using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class BombFireIncreaseTests : TestBase
    {
        private BombFireIncrease bombFireIncrease;

        public void ShouldBeCorrectTypeWhenCreated()
        {
            bombFireIncrease = new BombFireIncrease((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUIncreaseBombRange, bombFireIncrease.type);
        }
    }
}
