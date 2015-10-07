namespace Tests
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GameModels;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Validation;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfGameModelIsCreatedWithInitializedField()
        {
            var gameModel = new GameModel();
            Assert.IsNotNull(gameModel.Field);
        }

        [TestMethod]
        public void TestIfFieldPropertyReturnsTheSameValueItIsSetTo()
        {
            var game = new GameModel();
            var field = new IBalloon[5, 10];
            game.Field = field;

            Assert.AreEqual(field, game.Field);
        }

        [TestMethod]
        public void TestIfFieldPropertyReturnTheSameFieldItIsSetTo()
        {
            var field = new IBalloon[5, 10];
            var gameModel = new GameModel();
            gameModel.Field = field;
            Assert.AreSame(field, gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new GameModel();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfIncrementMovesMethodCorrectlyIncrementTheMovesCount()
        {
            var gameModel = new GameModel();
            gameModel.IncrementMoves();
            Assert.AreEqual(1, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodCorrectlyResetsTheUserMovesCount()
        {
            var gameModel = new GameModel();
            gameModel.IncrementMoves();
            gameModel.ResetUserMoves();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }
    }
}