namespace Tests
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Common;
    using BaloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfGameModelIsCreatedWithInitializedField()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator()));
            Assert.IsNotNull(gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator()));
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodResetsTheGameFieldCorrectly()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator()));
            var fieldBeforeReset = (byte[,])gameModel.Field.Clone();
            gameModel.Reset();

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

            Assert.IsTrue(gameModel.Field.Length / differentFieldCount < 2);
        }

        [TestMethod]
        public void TestIfIncrementMovesMethodCorrectlyIncrementTheMovesCount()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator()));
            gameModel.IncrementMoves();
            Assert.AreEqual(1, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodCorrectlyResetsTheUserMovesCount()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator()));
            gameModel.IncrementMoves();
            gameModel.Reset();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }
    }
}