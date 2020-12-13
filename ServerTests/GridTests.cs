using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace ServerTests
{
    [TestClass]
    public class GridTests : TestBase
    {

        [TestMethod]
        public void Should_ReturnDefaultSize13()
        {
            Grid grid = new Grid();
            int actual = grid.getSize();
            int expected = 13;
            Assert.AreEqual(expected, actual, "Grid default size is wrong");

        }
        [TestMethod]
        public void Should_ReturnCustomSize0()
        {
            Grid grid = new Grid(0);
            int actual = grid.getSize();
            int expected = 0;
            Assert.AreEqual(expected, actual, "Grid custom size is wrong");

        }
        [TestMethod]
        public void Should_ReturnCustomSize10()
        {
            Grid grid = new Grid(10);
            int actual = grid.getSize();
            int expected = 10;
            Assert.AreEqual(expected, actual, "Grid custom size is wrong");

        }
        [TestMethod]
        public void Should_ReturnFilled0()
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
                    CollectionAssert.AreEqual(expected[i, j], actual[i, j]);
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
        [DataRow(-1, 2, 1)]
        [DataRow(3, -1, 2)]
        [DataRow(14, 10, 3)]
        [DataRow(6, 14, 10)]
        [DataRow(-1, 15, 0)]
        [TestMethod]
        public void Should_ReturnFalseAddToTile_When_OutOfBound(int i, int j, int x)
        {
            Grid grid = new Grid(13);

            bool actual = grid.AddToTile(i, j, x);
            bool expected = false;


            Assert.AreEqual(expected, actual);
        }
        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_UpdateTile(int i, int j)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                1,
                2,
                3
            };

            grid.UpdateTile(i, j, tileList);
            List<int>[,] actual = grid.GetGrid();
            List<int>[,] expected = new List<int>[13, 13];
            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    expected[k, l] = new List<int>();
                }
            }
            expected[i, j] = tileList;

            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    CollectionAssert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
        [DataRow(-1, 2)]
        [DataRow(3, -1)]
        [DataRow(14, 10)]
        [DataRow(6, 14)]
        [DataRow(-1, 15)]
        [TestMethod]
        public void Should_ReturnFalseUpdateTile_When_OutOfBound(int i, int j)
        {
            Grid grid = new Grid(13);
            List<int> tileList = new List<int>
            {
                1,
                2,
                3
            };
            bool actual = grid.UpdateTile(i, j, tileList);
            bool expected = false;


            Assert.AreEqual(expected, actual);
        }
        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_ReturnTileGetTile(int i, int j)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                1,
                2,
                3
            };
            grid.UpdateTile(i, j, tileList);
            List<int> actual = grid.GetTile(i, j);
            List<int> expected = tileList;


            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(-1, 2)]
        [DataRow(3, -1)]
        [DataRow(14, 10)]
        [DataRow(6, 14)]
        [DataRow(-1, 15)]
        [TestMethod]
        public void Should_ReturnNullReturnTile_When_OutOfBound(int i, int j)
        {
            Grid grid = new Grid(13);

            List<int> actual = grid.GetTile(i, j);
            List<int> expected = null;


            Assert.AreEqual(expected, actual);
        }
        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_CleanGrid(int i, int j)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                1,
                2,
                3
            };
            grid.UpdateTile(i, j, tileList);
            grid.Clean();

            List<int>[,] actual = grid.GetGrid();
            List<int>[,] expected = new List<int>[13, 13];
            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    expected[k, l] = new List<int>();
                }
            }


            for (int k = 0; k < 13; k++)
            {
                for (int l = 0; l < 13; l++)
                {
                    CollectionAssert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
        [DataRow(1, 2, 1)]
        [DataRow(3, 0, 4)]
        [DataRow(5, 10, 5)]
        [DataRow(6, 6, 6)]
        [DataRow(0, 1, 7)]
        [TestMethod]
        public void Should_RemoveFromTile_When_1Exists(int i, int j, int x)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                x,
                2,
                3
            };
            grid.UpdateTile(i, j, tileList);
            grid.RemoveFromTile(i, j, x);
            List<int> actual = grid.GetTile(i, j);
            List<int> expected = new List<int>
            {
                2,
                3
            };



            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(1, 2, 2)]
        [DataRow(3, 0, 3)]
        [DataRow(5, 10, 2)]
        [DataRow(6, 6, 3)]
        [DataRow(0, 1, 2)]
        [TestMethod]
        public void Should_RemoveFromTile_When_2Exists(int i, int j, int x)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                x,
                2,
                3
            };
            grid.UpdateTile(i, j, tileList);
            grid.RemoveFromTile(i, j, x);
            List<int> actual = grid.GetTile(i, j);
            List<int> expected = new List<int>
            {
                2,
                3
            };



            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(1, 2, 4)]
        [DataRow(3, 0, 5)]
        [DataRow(5, 10, 6)]
        [DataRow(6, 6, 7)]
        [DataRow(0, 1, 8)]
        [TestMethod]
        public void Should_RemoveFromTile_When_0Exists(int i, int j, int x)
        {
            Grid grid = new Grid();
            List<int> tileList = new List<int>
            {
                1,
                2,
                3
            };
            grid.UpdateTile(i, j, tileList);
            grid.RemoveFromTile(i, j, x);
            List<int> actual = grid.GetTile(i, j);
            List<int> expected = new List<int>
            {
                1,
                2,
                3
            };



            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(-1, 2, 1)]
        [DataRow(3, -1, 2)]
        [DataRow(14, 10, 0)]
        [DataRow(6, 14, 10)]
        [DataRow(-1, 15, -1)]
        [TestMethod]
        public void Should_RemoveFromTile_When_OutOfBound(int i, int j, int x)
        {
            Grid grid = new Grid();
            bool expected = false;

            bool actual = grid.RemoveFromTile(i, j, x);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_AddTiles()
        {
            int[,] data = new int[13, 13] {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0, 14, 14, 14,0,0 },
                { 0,0,6,0,6,0,6,0,6,0,6, 14,0 },
                { 0,0, 14, 14, 14, 14, 14, 14,0, 14,0, 14,0 },
                { 0,0,6,0,6, 14,6,0,6, 14,6, 14,0 },
                { 23,0,0,0, 14, 14,0,0, 14, 14, 14, 14,0 },
                { 23,0,6,0,6, 14,6, 14,6, 14,6,0,0 },
                { 23,0,0,0, 14, 14, 14, 14, 14, 14, 14,0,0 },
                { 23,0,6, 14,6, 14,6, 14,6, 14,6,0,0 },
                { 0,0, 14, 14,0, 14, 14, 14, 14,0, 14,0,0 },
                { 0,0,6,0,6, 14,6, 14,6, 14,6,0,0 },
                { 0,0, 14, 14, 14, 14,0, 14,0,0, 14,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0 }};

            Grid grid = new Grid();
            grid.AddTiles(data);
            List<int>[,] expected = new List<int>[13, 13];

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    expected[i, j] = new List<int>();
                    if (data[i, j] != 0)
                    {
                        expected[i, j].Add(data[i, j]);
                    }
                }
            }
            List<int>[,] actual = grid.GetGrid();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    CollectionAssert.AreEqual(expected[i, j], actual[i, j]);
                }
            }

        }
        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_ReturnPowersAt_When_1Power(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = new List<int>
            {
               (int) TileEnumerator.TileTypeEnum.PUIncreaseBombRange,
            };
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUIncreaseBombRange);

            List<int> actual = grid.ReturnPowersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_ReturnPowersAt_When_3Power(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = new List<int>
            {
               (int) TileEnumerator.TileTypeEnum.PUIncreaseBombRange,
                (int) TileEnumerator.TileTypeEnum.PUBombKick,
               (int) TileEnumerator.TileTypeEnum.PUTemporarySwim,

            };
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUIncreaseBombRange);
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUBombKick);
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUTemporarySwim);

            List<int> actual = grid.ReturnPowersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(-1, 2)]
        [DataRow(3, -1)]
        [DataRow(14, 10)]
        [DataRow(6, 14)]
        [DataRow(-1, 15)]
        [TestMethod]
        public void Should_ReturnFalsePowersAt_When_OutOfBound(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = null;

            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUIncreaseBombRange);
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUBombKick);
            grid.AddToTile(i, j, (int) TileEnumerator.TileTypeEnum.PUTemporarySwim);
            List<int> actual = grid.ReturnPowersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_ReturnPlayersAt_When_1Player(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = new List<int>
            {
               1
            };
            grid.AddToTile(i, j, 1);


            List<int> actual = grid.ReturnPlayersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataRow(1, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 10)]
        [DataRow(6, 6)]
        [DataRow(0, 1)]
        [TestMethod]
        public void Should_ReturnPlayersAt_When_3Player(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = new List<int>
            {
               1,2,3
            };
            grid.AddToTile(i, j,1);
            grid.AddToTile(i, j, 2);
            grid.AddToTile(i, j, 3);

            List<int> actual = grid.ReturnPlayersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }
        [DataRow(-1, 2)]
        [DataRow(3, -1)]
        [DataRow(14, 10)]
        [DataRow(6, 14)]
        [DataRow(-1, 15)]
        [TestMethod]
        public void Should_ReturnNullPlayersAt_When_OutOfBound(int i, int j)
        {
            Grid grid = new Grid();
            List<int> expected = null;

            grid.AddToTile(i, j, 1);
            grid.AddToTile(i, j, 2);
            grid.AddToTile(i, j, 3);
            List<int> actual = grid.ReturnPlayersAt(i, j);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
