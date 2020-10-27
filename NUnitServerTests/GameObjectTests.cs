using NUnit.Framework;
using Server;
using System;
using System.Collections.Generic;

namespace NUnitServerTests
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void ShouldReturnEmtyTagsWhenCreated()
        {
            GameObject gameObject = new GameObject(new Coordinates(0,0));


            Assert.AreEqual(gameObject.GetTags(), new List<String>());
        }
    }
}
