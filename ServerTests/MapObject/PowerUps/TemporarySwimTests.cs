using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class TemporarySwimTests
    {
        private TemporarySwim temporarySwim;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            temporarySwim = new TemporarySwim((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(TileEnumerator.TileTypeEnum.PUTemporarySwim, temporarySwim.type);
        }

    }
}
