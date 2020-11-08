using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.CommandPattern;
using Server.MapObject;
using System;
using System.Collections.Generic;

namespace ServerTests
{
    [TestClass]
    public class PlayerTests
    {
        private WallsAdapter wallsAdapter;
        private List<int>[,] gridWalls;
        private Player player;

        [TestInitialize]
        public void Initialize()
        {
            Walls walls = new Walls();
            wallsAdapter = new WallsAdapter(walls);
            gridWalls = wallsAdapter.GetGrid();

            App.CreateInstance(new AppOptions());
            App.Inst.Arena = new GameArena(0);
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
            Assert.IsTrue(player.CanMove(ArenaCommandEnum.MoveRight, grid));
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
    }
}
