namespace Tests
{
    using System;
    using BalloonsPop.Validation;
    using BalloonsPop.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using System.Linq;

    using BalloonsPop.LogicProvider;
    using BalloonsPop.GameModels;

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
            var field = new LogicProvider(new MatrixValidator(), new RandomNumberGenerator()).GenerateField();
            var gameModel = new GameModel();
            gameModel.Field = field;
            Assert.AreEqual(field, gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new GameModel();
            gameModel.Field = new LogicProvider(new MatrixValidator(), new RandomNumberGenerator()).GenerateField();
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