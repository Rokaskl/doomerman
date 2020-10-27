using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace ServerTests
{
    [TestClass]
    class UserTests
    {
        [TestMethod]
        public void ExceptionShouldBeThrownIfIDGreaterThan4()
        {
            Assert.ThrowsException<Exception>(() => { User user = new User(5); });
        }

        [TestMethod]
        public void ExceptionShouldBeThrownIfIDLessThan0()
        {
            Assert.ThrowsException<Exception>(() => { User user = new User(-1); });
        }

        [TestMethod]
        public void UsernameShouldBeDifferent()
        {
            User user1 = new User(1, "testname");
            User user2 = new User(2, "testname");
            Assert.AreNotEqual(user1.Username, user2.Username);
        }

        [TestMethod]
        public void IDShouldIncreaseWhenCreatingEmptyUser()
        {
            User user1 = new User();
            int id1 = user1.Id;
            User user2 = new User();
            int id2 = user2.Id;
            Assert.AreEqual(2, id2);
        }

    }
}
