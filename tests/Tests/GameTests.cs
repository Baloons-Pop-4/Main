namespace Tests
{
    using System;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfGameModelIsCreatedWithInitializedField()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance).GenerateField());
            Assert.IsNotNull(gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance).GenerateField());
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodResetsTheGameFieldCorrectly()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance).GenerateField());
            var fieldBeforeReset = (byte[,])gameModel.Field.Clone();
            gameModel.Field = new byte[5, 10];

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
            var gameModel = new Game(new byte[5, 10]);
            gameModel.IncrementMoves();
            Assert.AreEqual(1, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodCorrectlyResetsTheUserMovesCount()
        {
            var gameModel = new Game(new GameLogic(MatrixValidator.GetInstance).GenerateField());
            gameModel.IncrementMoves();
            gameModel.ResetUserMoves();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }
    }
}