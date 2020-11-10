using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System;
using System.Collections.Generic;
using System.Text;
using static Server.App;

namespace ServerTests
{
    [TestClass]
    public abstract class TestBase
    {
        protected User User { get; } = new User(1, "user");
        static protected Application Inst => App.Inst;

        public TestBase()
        {
            App.CreateInstance(new AppOptions { ArenaId = 1 });
        }
    }
}
