using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;

namespace ServerTests.MapObject
{
    [TestClass]
    public class ExplosiveTests : TestBase
    {
        private Mock<Coordinates> cords;

        [TestInitialize]
        public void TestInitialize() => this.cords = new Mock<Coordinates>();


        private Explosive CreateExplosive() => new Explosive();

        [TestMethod]
        public void ShouldIncreaseRadiusBy1ThanIncRadiusCalled()
        {
            // Arrange
            Explosive explosive = this.CreateExplosive();
            int expexted = explosive.Radius + 1;

            // Act
            explosive.IncRadius();
            int actual = explosive.Radius;

            // Assert
            Assert.AreEqual(expexted, actual);

        }

        [TestMethod]
        public void ShouldDecreaseRadiusBy1ThanDecRadiusCalled()
        {
            // Arrange
            Explosive explosive = this.CreateExplosive();
            int expexted = explosive.Radius -1;

            // Act
            explosive.DecRadius();
            int actual = explosive.Radius;

            // Assert
            Assert.AreEqual(expexted, actual);

        }
        [TestMethod]
        public void ShouldReturnExplosiveTag()
        {
            // Arrange
            Explosive explosive = this.CreateExplosive();

            // Act
            System.Collections.Generic.List<string> result = explosive.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Explosive");
        }



        [TestMethod]
        public void ShouldSetandGetCordsCoordinates()
        {
            // Arrange
            Explosive explosive = this.CreateExplosive();

            // Act
            explosive.SetCords(this.cords.Object);
            Coordinates result = explosive.GetCords();

            // Assert
            Assert.AreEqual(this.cords.Object, result);
        }

    }
}
