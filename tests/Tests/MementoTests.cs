namespace Tests
{
    using System;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Engine.Memento;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using System.Linq;
    using Tests.MockClasses;
    using System.Runtime.Serialization;

    [TestClass]
    public class MementoTests
    {
        private readonly IMemento<IGameModel> memento = new Memento<IGameModel>();
        private readonly IGameLogicProvider logic = new GameLogic(MatrixValidator.GetInstance);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfMementoStateThrowsExceptionWhenNoStateIsProvidedButAStateIsRequeste()
        {
            var state = this.memento.State;
        }

        [TestMethod]
        [ExpectedException(typeof (SerializationException))]
        public void TestIfMementoThrowsAnExceptionWhenNoCloneableObjectIsProvided()
        {
            var notClonableObj = new MockPrinter();

            new Memento<IPrinter>().State = notClonableObj;
        }

        [TestMethod]
        public void TestIfMementoReturnsTheSameStateItAccepter()
        {
            var game = new Game(logic.GenerateField());

            this.memento.State = game;

            var stateFromMemento = this.memento.State;

            var areEqual = new QueriableMatrix<IBalloon>(game.Field)
                                .Join(new QueriableMatrix<IBalloon>(stateFromMemento.Field), x => x, y => y, (x, y) => (x.isPopped == y.isPopped) && (x.Number == y.Number))
                                .All(x => x);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestIfConstructorWithParametersHasTheSameBehaviorAsTheSetter()
        {
            var game = new Game(logic.GenerateField());

            this.memento.State = game;
            var memento2 = new Memento<IGameModel>(game);


            var stateFromMemento = this.memento.State;

            var areEqual = new QueriableMatrix<IBalloon>(memento2.State.Field)
                                .Join(new QueriableMatrix<IBalloon>(stateFromMemento.Field), x => x, y => y, (x, y) => (x.isPopped == y.isPopped) && (x.Number == y.Number))
                                .All(x => x);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestIfMementoProvidesDeepCopy()
        {
            var game = new Game(logic.GenerateField());

            this.memento.State = game;

            var stateFromMemento = this.memento.State;

            game.Field[0, 0].isPopped = true;

            Assert.IsFalse(ReferenceEquals(game.Field, stateFromMemento.Field));

            bool areEqual = true;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(game.Field[i,j].isPopped != stateFromMemento.Field[i, j].isPopped)
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
            var game = new Game(this.logic.GenerateField());

            this.memento.State = game;
            this.memento.State.Field[0, 0].Number = 99;

            Assert.AreNotEqual(this.memento.State.Field[0, 0].Number, 99);

            var moves = this.memento.State.UserMovesCount;
            this.memento.State.IncrementMoves();
            var moves2 = this.memento.State.UserMovesCount;

            Assert.AreEqual(moves, moves2);

        }
    }
}