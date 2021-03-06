﻿namespace Tests
{
    using System;
    using System.Linq;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Saver;
    using BalloonsPop.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MementoTests
    {
        private IStateSaver<IGameModel> memento;
        private IGameLogicProvider logic;

        [TestInitialize]
        public void TestInit()
        {
            this.memento = new Saver<IGameModel>();
            this.logic  = new LogicProvider(new MatrixValidator(), new RandomNumberGenerator());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfMementoStateThrowsExceptionWhenNoStateIsProvidedButAStateIsRequeste()
        {
            var state = this.memento.GetState();
        }

        [TestMethod]
        public void TestIfMementoReturnsTheSameStateItAccepter()
        {
            var game = new GameModel();
            this.logic.RandomizeBalloonField(game.Field);
            this.memento.SaveState(game);

            var stateFromMemento = this.memento.GetState();

            var areEqual = new QueryableMatrix<IBalloon>(game.Field)
                                .Join(new QueryableMatrix<IBalloon>(stateFromMemento.Field), x => x, y => y, (x, y) => (x.IsPopped == y.IsPopped) && (x.Number == y.Number))
                                .All(x => x);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestIfConstructorWithParametersHasTheSameBehaviorAsTheSetter()
        {
            var game = new GameModel();
            this.logic.RandomizeBalloonField(game.Field);
            this.memento.SaveState(game);
            var memento2 = new Saver<IGameModel>();
            memento2.SaveState(game);

            var stateFromMemento = this.memento.GetState();

            var areEqual = new QueryableMatrix<IBalloon>(memento2.GetState().Field)
                                .Join(new QueryableMatrix<IBalloon>(stateFromMemento.Field), x => x, y => y, (x, y) => (x.IsPopped == y.IsPopped) && (x.Number == y.Number))
                                .All(x => x);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestIfMementoProvidesDeepCopy()
        {
            var game = new GameModel();
            this.logic.RandomizeBalloonField(game.Field);
            this.memento.SaveState(game);

            var stateFromMemento = this.memento.GetState();

            game.Field[0, 0].IsPopped = true;

            Assert.IsFalse(ReferenceEquals(game.Field, stateFromMemento.Field));

            bool areEqual = true;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.Field[i, j].IsPopped != stateFromMemento.Field[i, j].IsPopped)
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void TestIfGetterEncapsulatesTheCurrentState()
        {
            var game = new GameModel();
            this.logic.RandomizeBalloonField(game.Field);
            this.memento.SaveState(game);
            var state = this.memento.GetState();

            state.Field[0, 0].Number = 99;

            Assert.AreNotEqual(game.Field[0, 0].Number, 99);

            var moves = state.UserMovesCount;

            game.IncrementMoves();
            var moves2 = game.UserMovesCount;

            Assert.AreNotEqual(moves, moves2);
        }

        [TestMethod]
        public void TestIfHasStatesReturnsTrueWhenThereArePushedStates()
        {
            var game = new GameModel();
            this.memento.SaveState(game);
            Assert.IsTrue(this.memento.HasStates);
        }

        [TestMethod]
        public void TestIfHasStatesReturnsFalseWhenThereAreNoPushedStates()
        {
            Assert.IsFalse(this.memento.HasStates);
        }
    }
}