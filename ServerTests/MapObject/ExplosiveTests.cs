using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using System;

namespace ServerTests.MapObject
{
    [TestClass]
    public class ExplosiveTests
    {
        private MockRepository mockRepository;
        private Coordinates cords;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.cords = new Coordinates();

        }

        private Explosive CreateExplosive()
        {
            return new Explosive();
        }

        [TestMethod]
        public void ShouldIncreaseRadiusBy1ThanIncRadiusCalled()
        {
            // Arrange
            var explosive = this.CreateExplosive();
            var expexted = explosive.Radius + 1;

            // Act
            explosive.IncRadius();
            var actual = explosive.Radius;

            // Assert
            Assert.AreEqual(expexted, actual);
           
        }

        [TestMethod]
        public void ShouldDecreaseRadiusBy1ThanDecRadiusCalled()
        {
            // Arrange
            var explosive = this.CreateExplosive();
            var expexted = explosive.Radius -1;

            // Act
            explosive.DecRadius();
            var actual = explosive.Radius;

            // Assert
            Assert.AreEqual(expexted, actual);

        }
        [TestMethod]
        public void ShouldReturnExplosiveTag()
        {
            // Arrange
            var explosive = this.CreateExplosive();

            // Act
            var result = explosive.GetTags();

            // Assert
            CollectionAssert.Contains(result, "Explosive");
        }

       

        [TestMethod]
        public void ShouldSetandGetCordsCoordinates()
        {
            // Arrange
            var explosive = this.CreateExplosive();
            
            // Act
            explosive.SetCords(cords);
            Coordinates result = explosive.GetCords();

            // Assert
            Assert.AreEqual(cords, result);
        }
        
    }
}
