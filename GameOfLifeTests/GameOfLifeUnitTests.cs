using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeUnitTests
    {
        [TestMethod]
        public void ResurectionCausedThreeNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Resurection.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
        }

        [TestMethod]
        public void DeathCausedMoreThanThreeNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Death4Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
        }

        [TestMethod]
        public void DeathCausedLessThanTwoNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Death1Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
        }

        [TestMethod]
        public void StayedAliveCausedThreeNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Alive3Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
        }

        [TestMethod]
        public void StayedAliveCausedTwoNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Alive2Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
        }

        [TestMethod]
        public void StayedDeadCausedMoreThanThreeNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Death5Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
        }

        [TestMethod]
        public void StayedDeadCausedLessThanThreeNeighbor()
        {
            var game = new GameOfLife.GameOfLife("Death2Nei.txt");
            game.NextAge();
            Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
        }
    }
}