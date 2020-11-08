using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class ExtraLifeTests
    {
        private ExtraLife extraLife;
        
        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            extraLife = new ExtraLife((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(TileEnumerator.TileTypeEnum.PUExtraLife, extraLife.type);
        }
    }
}
