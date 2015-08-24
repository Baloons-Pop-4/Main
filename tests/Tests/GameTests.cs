namespace Tests
{
    using System;
    using BaloonsPop.Common;
    using BaloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfGameModelIsCreatedWithInitializedField()
        {
            var gameModel = new Game(new BaloonField());
            Assert.IsNotNull(gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new Game(new BaloonField());
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodResetsTheGameFieldCorrectly()
        {
            var gameModel = new Game(new BaloonField());
            var fieldBeforeReset = (byte[,])gameModel.Field.Baloons.Clone();

            var provider = new GameLogic(null, new RandomNumberGenerator());
            provider.RandomizeBaloonField(gameModel.Field);

            var differentFieldCount = 0;

            for (int i = 0; i < fieldBeforeReset.GetLength(0); i++)
            {
                for (int j = 0; j < fieldBeforeReset.GetLength(1); j++)
                {
                    if (fieldBeforeReset[i, j] != gameModel.Field[i, j])
                    {
                        differentFieldCount++;
                    }
                }
            }

            Assert.IsTrue(gameModel.Field.Baloons.Length / differentFieldCount < 2);
        }

        [TestMethod]
        public void TestIfIncrementMovesMethodCorrectlyIncrementTheMovesCount()
        {
            var gameModel = new Game(new BaloonField());
            gameModel.IncrementMoves();
            Assert.AreEqual(1, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfNullifyMethodSetsTheUserMovesCountToZero()
        {
            var gameModel = new Game(new BaloonField());
            gameModel.IncrementMoves();
            new GameLogic(null, new RandomNumberGenerator()).RandomizeBaloonField(gameModel.Field);
            gameModel.NullifyUserMoves();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }
    }
}