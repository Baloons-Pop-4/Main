namespace Tests
{
    using System;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using System.Linq;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfGameModelIsCreatedWithInitializedField()
        {
            var gameModel = new GameModel(new LogicProvider(MatrixValidator.GetInstance).GenerateField());
            Assert.IsNotNull(gameModel.Field);
        }

        [TestMethod]
        public void TestIfFieldPropertyReturnsTheSameValueItIsSetTo()
        {
            var game = new GameModel(null);
            var field = new IBalloon[5, 10];
            game.Field = field;

            Assert.AreEqual(field, game.Field);
        }

        [TestMethod]
        public void TestIfFieldPropertyReturnTheSameFieldItIsSetTo()
        {
            var field = new LogicProvider(MatrixValidator.GetInstance).GenerateField();
            var gameModel = new GameModel(field);
            Assert.AreEqual(field, gameModel.Field);
        }

        [TestMethod]
        public void TestIfInitialMovesCountIsZero()
        {
            var gameModel = new GameModel(new LogicProvider(MatrixValidator.GetInstance).GenerateField());
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfIncrementMovesMethodCorrectlyIncrementTheMovesCount()
        {
            var gameModel = new GameModel(new IBalloon[5, 10]);
            gameModel.IncrementMoves();
            Assert.AreEqual(1, gameModel.UserMovesCount);
        }

        [TestMethod]
        public void TestIfResetMethodCorrectlyResetsTheUserMovesCount()
        {
            var gameModel = new GameModel(new LogicProvider(MatrixValidator.GetInstance).GenerateField());
            gameModel.IncrementMoves();
            gameModel.ResetUserMoves();
            Assert.AreEqual(0, gameModel.UserMovesCount);
        }
    }
}