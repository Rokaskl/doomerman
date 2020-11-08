using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using Server;
using System;
using System.Collections.Generic;

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
            List<int>[,] actual = grid.GetGrid();
            List<int>[,] expected = new List<int>[13, 13];
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {

                    expected[i, j] = new List<int>();
                }

            }

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    CollectionAssert.AreEqual(expected[i,j], actual[i,j]);
                }
            }


        }
        [DataRow(1, 2, 3)]
        [DataRow(3, 0, 4)]
        [DataRow(5, 10, 5)]
        [DataRow(6, 6, 1)]
        [DataRow(0, 12, 2)]
        [TestMethod]
        public void Should_AddItemToTile(int i, int j, int value)
        {
            Grid grid = new Grid();
            grid.AddToTile(i, j, value);

            List<int>[,] actual = grid.GetGrid();
            List<int>[,] expected = new List<int>[13, 13];

            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    expected[k, l] = new List<int>();
                }
            }
            expected[i, j].Add(value);


            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    CollectionAssert.AreEqual(expected[i, j], actual[i, j]);
                }
            }

        }
    }
}
