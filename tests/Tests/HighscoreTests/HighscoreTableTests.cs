namespace Tests.HighscoreTests
{
    using System;

    using BalloonsPop.Highscore;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Summary description for HighscoreTableTests
    /// </summary>
    [TestClass]
    public class HighscoreTableTests
    {
        [TestMethod]
        public void HighscoreTableShouldInitiallyHaveZeroPlayers()
        {
            HighscoreTable table = new HighscoreTable();
            Assert.AreEqual(0, table.Table.Count);
        }

        [TestMethod]
        public void HighscoreTableShouldWorkWithPredefinedListOfPlayers()
        {
            List<PlayerScore> playerScores = new List<PlayerScore> 
            {
                new PlayerScore("Pesho", 10, DateTime.Now),
                new PlayerScore("Pesho", 10, DateTime.Now),
                new PlayerScore("Pesho", 10, DateTime.Now),
                new PlayerScore("Pesho", 10, DateTime.Now)
            };

            HighscoreTable table = new HighscoreTable(playerScores);
            Assert.AreEqual(4, table.Table.Count);
        }

        [TestMethod]
        public void AddingPlayerToHighscoreTableShouldWorkCorrectly()
        {
            HighscoreTable table = new HighscoreTable();
            PlayerScore somePlayer = new PlayerScore("Pesho", 10, DateTime.Now);
            table.AddPlayer(somePlayer);
            Assert.AreEqual(1, table.Table.Count);
        }

        [TestMethod]
        public void HighscoreTableSizeShouldNotChangeWhenAddingMoreThanMaxPlayers()
        {
            List<PlayerScore> playerScores = new List<PlayerScore>();

            for (int i = 0; i < HighscoreTable.MaxPlayers; i++)
            {
                playerScores.Add(new PlayerScore(i.ToString(), i, DateTime.Now));
            }

            HighscoreTable table = new HighscoreTable(playerScores);
            PlayerScore somePlayer = new PlayerScore("Pesho", 10, DateTime.Now);
            table.AddPlayer(somePlayer);

            Assert.AreEqual(HighscoreTable.MaxPlayers, table.Table.Count);
        }

        [TestMethod]
        public void HighscoreTableShouldAddPlayerWhenNotReachedMaxPlayers()
        {
            List<PlayerScore> playerScores = new List<PlayerScore>();
            for (int i = 0; i < HighscoreTable.MaxPlayers - 1; i++)
            {
                playerScores.Add(new PlayerScore(i.ToString(), i, DateTime.Now));
            }
            HighscoreTable table = new HighscoreTable(playerScores);

            bool canAddPlayer = table.CanAddPlayer(10);

            Assert.IsTrue(canAddPlayer);
        }

        [TestMethod]
        public void HighscoreTableShouldAddPlayerWhenHisScoreIsLowerThanOthers()
        {
            List<PlayerScore> playerScores = new List<PlayerScore>();
            for (int i = 0; i < HighscoreTable.MaxPlayers; i++)
            {
                playerScores.Add(new PlayerScore(i.ToString(), i + 1, DateTime.Now));
            }
            HighscoreTable table = new HighscoreTable(playerScores);

            bool canAddPlayer = table.CanAddPlayer(0);

            Assert.IsTrue(canAddPlayer);
        }
    }
}
