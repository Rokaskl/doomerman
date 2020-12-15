using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class BombKickTests : TestBase
    {
        private BombKick bombKick;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            bombKick = new BombKick((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(Server.TileEnumerator.TileTypeEnum.PUBombKick, bombKick.type);
        }
    }
}
