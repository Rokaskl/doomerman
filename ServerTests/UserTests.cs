using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod]
        public void ShouldFailWhenUsernamesSame()
        {
            User user1 = new User();
            User user2 = new User();

            Assert.AreNotEqual(user1.Username, user2.Username);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(5)]
        public void ShouldFailWhenIDLessThan1OrGreaterThan4(int id)
        {
            Assert.ThrowsException<Exception>( () => { User user = new User(id); });
        }
    }
}