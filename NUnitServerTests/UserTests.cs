using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using Server;

namespace NUnitServerTests
{
    
    class UserTests
    {
        [Test]
        public void ShouldSetIDWhenAddingEmptyUser()
        {
            User user1 = new User();
            int id1 = user1.Id;
            User user2 = new User();
            int id2 = user2.Id;

            Assert.AreNotEqual(0, id2);
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void ShouldBeFrom1To4WhenSettingID(int id)
        {
            Assert.Throws<Exception>(() => { User user = new User(id, "test"); });
        }

        [Test]
        public void ShouldFailWhenUsernamesAreSame()
        {
            User user1 = new User();
            User user2 = new User();

            Assert.AreNotEqual(user1.Username, user2.Username);
        }
    }
}
