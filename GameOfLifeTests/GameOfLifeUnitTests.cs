using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeUnitTests
    {
        [TestMethod]
        public void ResurectionCausedThreeNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Resurection.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
            
        }

        [TestMethod]
        public void DeathCausedMoreThanThreeNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Death4Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
            
        }

        [TestMethod]
        public void DeathCausedLessThanTwoNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Death1Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
        }

        [TestMethod]
        public void StayedAliveCausedThreeNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Alive3Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
            }
            catch (ArgumentException e)
            {
                 Console.Write(e.Message);
            }
            
        }

        [TestMethod]
        public void StayedAliveCausedTwoNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Alive2Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), true);
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
            
        }

        [TestMethod]
        public void StayedDeadCausedMoreThanThreeNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Death5Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);  
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
        }

        [TestMethod]
        public void StayedDeadCausedLessThanThreeNeighbor()
        {
            try
            {
                var game = new GameOfLife.GameOfLife("Death2Nei.txt");
                game.NextAge();
                Assert.AreEqual(game.IsDeadOrAlive(1, 1), false);
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
            
        }
    }
}