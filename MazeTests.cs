namespace MazeKata
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MazeTests
    {
        // 1 2 3
        // 2 3 4
        // 3 4 5
        [TestMethod]
        public void EmptyMaze()
        {
            // arrange
            var maze = new Maze(3, 3);

            // act
            var dist = maze.Distance(0, 0, 2, 2);

            // assert
            Assert.AreEqual(5, dist);
        }

        // 1 2 w
        // 2 w _
        // w _ _
        [TestMethod]
        public void Disconnected()
        {
            // arrange
            var maze = new Maze(3, 3);
            maze.SetWall(2, 0);
            maze.SetWall(1, 1);
            maze.SetWall(0, 2);

            // act
            var connected = maze.AreConnected(0, 0, 2, 2);

            // assert
            Assert.AreEqual(false, connected);
        }

        // 1 w 7 
        // 2 w 6
        // 3 4 5
        [TestMethod]
        public void FindWay()
        {
            // arrange
            var maze = new Maze(3, 3);
            maze.SetWall(1, 0);
            maze.SetWall(1, 1);

            // act
            var dist = maze.Distance(0, 0, 2, 0);

            // assert
            Assert.AreEqual(7, dist);
        }
    }
}