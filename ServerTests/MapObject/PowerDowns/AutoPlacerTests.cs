using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerDowns
{
    [TestClass]
    public class AutoPlacerTests
    {
        private AutoPlacer autoPlacer;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            autoPlacer = new AutoPlacer(new Server.GameObject(new Server.Coordinates()));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUAutoPlacer, autoPlacer.type);
        }

    }
}
