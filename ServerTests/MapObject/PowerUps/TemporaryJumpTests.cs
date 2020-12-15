using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerTests.MapObject.PowerUps
{
    [TestClass]
    public class TemporaryJumpTests : TestBase
    {
        private TemporaryJump temporaryJump;

        [TestMethod]
        public void ShouldBeCorrectTypeWhenCreated()
        {
            temporaryJump = new TemporaryJump((new Server.GameObject(new Server.Coordinates())));
            Assert.AreEqual(TileEnumerator.TileTypeEnum.PUTemporaryJump, temporaryJump.type);
        }

    }
}
