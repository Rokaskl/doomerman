using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.Logic;
using System;

namespace ServerTests.Logic
{
    [TestClass]
    public class ArenaLogicTests : TestBase
    {

        [TestMethod]
        public void ShouldSetUpdate()
        {
            var arena = new GameArena(0);
            var logic = new ArenaLogic(arena);

            arena.isStarted = true;

            if (arena.isStarted)
            {
                arena.UpdateRequired = false;
            }

            Assert.AreEqual(false, arena.UpdateRequired);
        }
    }
}
