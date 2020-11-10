using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.MapObject;
using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ServerTests
{
    [TestClass]
    public class PlayerTests : TestBase
    {
        private WallsAdapter wallsAdapter;
        private List<int>[,] gridWalls;
        private Player player;
        private Mock<Sender> senderMock;

        [TestInitialize]
        public void Initialize()
        {
            Walls walls = new Walls();
            wallsAdapter = new WallsAdapter(walls);
            gridWalls = wallsAdapter.GetGrid();
            senderMock = new Mock<Sender>(User);
        }

        [TestMethod]
        [DataRow(ArenaCommandEnum.MoveUp, 0, 0)]
        [DataRow(ArenaCommandEnum.MoveDown, 0, 12)]
        [DataRow(ArenaCommandEnum.MoveLeft, 0, 0)]
        [DataRow(ArenaCommandEnum.MoveRight, 12, 0)]
        public void ShouldReturnFalseWhenMovingOutsideGrid(ArenaCommandEnum cmd, int x, int y)
        {
            player = new Player(new User());
            player.xy.X = x;
            player.xy.Y = y;

            Assert.IsFalse(player.CanMove(cmd, gridWalls));
        }

        [TestMethod]
        [DataRow(ArenaCommandEnum.MoveUp, 0, 12)]
        [DataRow(ArenaCommandEnum.MoveDown, 0, 0)]
        [DataRow(ArenaCommandEnum.MoveLeft, 12, 0)]
        [DataRow(ArenaCommandEnum.MoveRight, 0, 0)]
        public void ShouldReturnTrueWhenMovingInsideGrid(ArenaCommandEnum cmd, int x, int y)
        {
            player = new Player(new User());
            player.xy.X = x;
            player.xy.Y = y;

            Assert.IsTrue(player.CanMove(cmd, gridWalls));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Wall)]
        [DataRow(TileEnumerator.TileTypeEnum.Bomb)]
        [DataRow(TileEnumerator.TileTypeEnum.DestroyableWall)]
        [DataRow(TileEnumerator.TileTypeEnum.Water)]
        public void ShouldReturnFalseWhenNormalStrategyAndMovingIntoObstacles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveNormalStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsFalse(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Wall)]
        [DataRow(TileEnumerator.TileTypeEnum.DestroyableWall)]
        [DataRow(TileEnumerator.TileTypeEnum.Water)]
        public void ShouldReturnFalseWhenKickStrategyAndMovingIntoObstacles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveKickStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsFalse(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Wall)]
        [DataRow(TileEnumerator.TileTypeEnum.Bomb)]
        [DataRow(TileEnumerator.TileTypeEnum.DestroyableWall)]
        public void ShouldReturnFalseWhenSwimStrategyAndMovingIntoObstacles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveSwimStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsFalse(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Wall)]
        [DataRow(TileEnumerator.TileTypeEnum.DestroyableWall)]
        [DataRow(TileEnumerator.TileTypeEnum.Water)]
        public void ShouldReturnFalseWhenJumpStrategyAndMovingIntoObstacles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveJumpStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsFalse(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Player1)]
        [DataRow(TileEnumerator.TileTypeEnum.Player2)]
        [DataRow(TileEnumerator.TileTypeEnum.Player3)]
        [DataRow(TileEnumerator.TileTypeEnum.Player4)]
        [DataRow(TileEnumerator.TileTypeEnum.Empty)]
        [DataRow(TileEnumerator.TileTypeEnum.PUAutoPlacer)]
        [DataRow(TileEnumerator.TileTypeEnum.PUBombKick)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUExtraLife)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryJump)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryShield)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporarySwim)]
        public void ShouldReturnTrueWhenNormalStrategyAndMovingIntoAllowedTiles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveNormalStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsTrue(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Bomb)]
        [DataRow(TileEnumerator.TileTypeEnum.Player1)]
        [DataRow(TileEnumerator.TileTypeEnum.Player2)]
        [DataRow(TileEnumerator.TileTypeEnum.Player3)]
        [DataRow(TileEnumerator.TileTypeEnum.Player4)]
        [DataRow(TileEnumerator.TileTypeEnum.Empty)]
        [DataRow(TileEnumerator.TileTypeEnum.PUAutoPlacer)]
        [DataRow(TileEnumerator.TileTypeEnum.PUBombKick)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUExtraLife)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryJump)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryShield)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporarySwim)]
        public void ShouldReturnTrueWhenKickStrategyAndMovingIntoAllowedTiles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveKickStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Explosive go = new Explosive(1, 0);
            App.Inst.Arena.AddGameObject(go);

            bool move = player.CanMove(ArenaCommandEnum.MoveRight, grid);

            App.Inst.Arena.RemoveGameObject(go, 1, 0);
            Assert.IsTrue(move);
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Water)]
        [DataRow(TileEnumerator.TileTypeEnum.Player1)]
        [DataRow(TileEnumerator.TileTypeEnum.Player2)]
        [DataRow(TileEnumerator.TileTypeEnum.Player3)]
        [DataRow(TileEnumerator.TileTypeEnum.Player4)]
        [DataRow(TileEnumerator.TileTypeEnum.Empty)]
        [DataRow(TileEnumerator.TileTypeEnum.PUAutoPlacer)]
        [DataRow(TileEnumerator.TileTypeEnum.PUBombKick)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUExtraLife)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryJump)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryShield)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporarySwim)]
        public void ShouldReturnTrueWhenSwimStrategyAndMovingIntoAllowedTiles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveSwimStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsTrue(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.Bomb)]
        [DataRow(TileEnumerator.TileTypeEnum.Player1)]
        [DataRow(TileEnumerator.TileTypeEnum.Player2)]
        [DataRow(TileEnumerator.TileTypeEnum.Player3)]
        [DataRow(TileEnumerator.TileTypeEnum.Player4)]
        [DataRow(TileEnumerator.TileTypeEnum.Empty)]
        [DataRow(TileEnumerator.TileTypeEnum.PUAutoPlacer)]
        [DataRow(TileEnumerator.TileTypeEnum.PUBombKick)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUDecreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUExtraLife)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombExplosionTime)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombLimit)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseBombRange)]
        [DataRow(TileEnumerator.TileTypeEnum.PUIncreaseSpeed)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryJump)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryShield)]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporarySwim)]
        public void ShouldReturnTrueWhenJumpStrategyAndMovingIntoAllowedTiles(TileEnumerator.TileTypeEnum tileType)
        {
            player = new Player(new User());
            player.ChangeStrategy(new MoveJumpStrategy());

            List<int>[,] grid = wallsAdapter.GetGrid();
            grid[1, 0].Add((int)tileType);
            Assert.IsTrue(player.CanMove(ArenaCommandEnum.MoveRight, grid));
        }

        [TestMethod]
        public void ShouldAlwaysReturnTrueWhenCallingCanDropBomb()
        {
            player = new Player(new User());
            Assert.IsTrue(player.CanDropBomb());
        }

        [TestMethod]
        public void ShouldBeFalseWhenBombDropped()
        {
            player = new Player(new User());
            player.DropBomb();
            Assert.IsFalse(player.Bomb.Droped);
        }

        [TestMethod]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporaryJump, typeof(MoveJumpStrategy))]
        [DataRow(TileEnumerator.TileTypeEnum.PUTemporarySwim, typeof(MoveSwimStrategy))]
        [DataRow(TileEnumerator.TileTypeEnum.PUBombKick, typeof(MoveKickStrategy))]
        public void ShouldFailWhenIncorrectStrategyChosenAfterPowerUp(TileEnumerator.TileTypeEnum tileType, Type strategyType)
        {
            Pickable item = new Pickable();
            player = new Player(new User());

            item.type = tileType;
            player.AddPowerUp(item);

            Assert.AreEqual(player.moveStrategy.GetType(), strategyType);
        }

        [TestMethod]
        public void ShouldFailIfYDoesntDecreaseWhenMovingUp()
        {
            player = new Player(new User());
            int prevY = player.xy.Y;
            player.MoveUp();
            Assert.AreEqual(player.xy.Y, prevY - 1);
        }

        [TestMethod]
        public void ShouldFailIfYDoesntIncreaseWhenMovingDown()
        {
            player = new Player(new User());
            int prevY = player.xy.Y;
            player.MoveDown();
            Assert.AreEqual(player.xy.Y, prevY + 1);
        }

        [TestMethod]
        public void ShouldFailIfXDoesntDecreaseWhenMovingLeft()
        {
            player = new Player(new User());
            int prevX = player.xy.X;
            player.MoveLeft();
            Assert.AreEqual(player.xy.X, prevX - 1);
        }

        [TestMethod]
        public void ShouldFailIfXDoesntIncreaseWhenMovingRight()
        {
            player = new Player(new User());
            int prevX = player.xy.X;
            player.MoveRight();
            Assert.AreEqual(player.xy.X, prevX + 1);
        }

        [TestMethod]
        public void ShouldFailIfBombLimitOverMax()
        {
            player = new Player(new User());
            for (int i = 0; i < Server.constants.Constants.MaxBombLimit + 10; i++)
            {
                player.IncBombLimit();
            }

            Assert.AreEqual(player.BombLimit, Server.constants.Constants.MaxBombLimit);
        }

        [TestMethod]
        public void ShouldFailIfBombLimitLessThanOne()
        {
            player = new Player(new User());
            for (int i = 0; i < Server.constants.Constants.MaxBombLimit; i++)
            {
                player.DecBombLimit();
            }

            Assert.AreEqual(player.BombLimit, 1);
        }

        [TestMethod]
        public void ShouldCallSendWhenUpdateIsCalled()
        {
            player = new Player(User);
            senderMock.Setup(x => x.Send(It.IsAny<int>(), It.IsAny<string>()));
            player.sender = senderMock.Object;

            player.Update(new Grid(), new List<int>());

            senderMock.Verify(x => x.Send(It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
