using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System;

namespace ServerTests
{
    [TestClass]
    public class GridTests
    {

        [TestMethod]
        public void Should_ReturnDefaultSize13_Than_Created()
        {
            Grid grid = new Grid();
            int actual = grid.getSize();
            int expected = 13;
            Assert.AreEqual(expected, actual, "Grid default size is wrong");

        }
        [TestMethod]
        public void Should_ReturnCustomSize0_Than_Created()
        {
            Grid grid = new Grid(0);
            int actual = grid.getSize();
            int expected = 0;
            Assert.AreEqual(expected, actual, "Grid custom size is wrong");

        }
        [TestMethod]
        public void Should_ReturnCustomSize10_Than_Created()
        {
            Grid grid = new Grid(10);
            int actual = grid.getSize();
            int expected = 10;
            Assert.AreEqual(expected, actual, "Grid custom size is wrong");

        }
        [TestMethod]
        public void Should_ReturnFilled0_Than_Created()
        {
            Grid grid = new Grid();
            int[,] actual = grid.getGrid();
            int[,] expected = new int[13, 13] 
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } 
            };
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
