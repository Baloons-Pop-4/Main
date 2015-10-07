namespace Tests
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Validation;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameLogicTests
    {
        private LogicProvider gameLogicProvider;

        public GameLogicTests()
        {
            this.gameLogicProvider = new LogicProvider(new MatrixValidator(), new RandomNumberGenerator());
        }

        [TestMethod]
        public void TestIfGenerateFieldReturnsFieldThatAreSignificantlyDifferentFromEachOther()
        {
            var game = new GameModel().Field;
            this.gameLogicProvider.RandomizeBalloonField(game);
            var first = new GameModel().Field;

            this.gameLogicProvider.RandomizeBalloonField(first);

            var differenceCount = 0;

            for (int i = 0; i < game.GetLength(0); i++)
            {
                for (int k = 0; k < game.GetLength(1); k++)
                {
                    if (game[i, k].Number != first[i, k].Number)
                    {
                        differenceCount++;
                    }
                }
            }

            var numberOfCells = game.GetLength(0) * game.GetLength(1);

            Assert.IsTrue(differenceCount > (numberOfCells / 3));
        }

        [TestMethod]
        public void TestIfGenerateFieldInitializesTheFieldWithCorrectBalloonValues()
        {
            for (int i = 0; i < 10; i++)
            {
                var game = new GameModel();

                this.gameLogicProvider.RandomizeBalloonField(game.Field);

                foreach (var cell in game.Field)
                {
                    if (cell.Number <= 0 || 5 <= cell.Number)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsTrueWithAnEmptyField()
        {
            var sampleEmptyField = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon() { IsPopped = true }).ToMatrix(5, 10);
            Assert.IsTrue(this.gameLogicProvider.GameIsOver(sampleEmptyField));
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithANonemptyField()
        {
            var rng = new Random();
            var sampleEmptyField = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon()).ToMatrix(5, 10);
            for (int i = 0; i < 50; i++)
            {
                sampleEmptyField[rng.Next(0, 5), rng.Next(0, 10)] = new Balloon() { Number = (byte)rng.Next(1, 5) };

                Assert.IsFalse(this.gameLogicProvider.GameIsOver(sampleEmptyField));
            }
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithFullField()
        {
            var game = new GameModel();

            this.gameLogicProvider.RandomizeBalloonField(game.Field);

            Assert.IsFalse(this.gameLogicProvider.GameIsOver(game.Field));
        }

        [TestMethod]
        public void TestIfPopBalloonsPopsTheBalloonsOnTheSameRowAndColumn()
        {
            var field = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon()).ToQueriableMatrix(5, 10);

            for (int i = 0, j = 5; i < 5; i++)
            {
                field.Value[i, j].Number = (byte)1;
            }

            for (int i = 0, j = 2; i < 10; i++)
            {
                field.Value[j, i].Number = (byte)1;
            }

            this.gameLogicProvider.PopBalloons(field.Value, 2, 5);

            Assert.IsTrue(field.Any(x => x.IsPopped));
        }

        [TestMethod]
        public void TestIfPopBalloonsPopsOnlyTheBalloonsOnTheSameRowAndColumn()
        {
            var game = new GameModel();
            this.gameLogicProvider.RandomizeBalloonField(game.Field);
            var storedField = game.Clone().Field;

            for (int i = 0, j = 5; i < 5; i++)
            {
                game.Field[i, j].Number = (byte)1;
            }

            for (int i = 0, j = 2; i < 10; i++)
            {
                game.Field[j, i].Number = (byte)1;
            }

            this.gameLogicProvider.PopBalloons(game.Field, 2, 5);

            for (int i = 0; i < game.Field.GetLength(0); i++)
            {
                for (int j = 0; j < game.Field.GetLength(1); j++)
                {
                    if (i == 2 || j == 5)
                    {
                        if (!game.Field[i, j].IsPopped)
                        {
                            Assert.Fail();
                        }
                    }
                    else
                    {
                        if (storedField[i, j].IsPopped)
                        {
                            Assert.Fail();
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestIfPopBalloonsPopsOnlyTargetBalloonWhenTheBalloonHasNoNeighborsOfTheSameType()
        {
            var field = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon()).ToMatrix(5, 10);

            for (int i = 1; i < 4; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    field[i, j].Number = (byte)((i == 2 && j == 3) ? 1 : 2);
                }
            }

            this.gameLogicProvider.PopBalloons(field, 2, 3);

            for (int i = 1; i < 4; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    if (i != 2 && j != 3)
                    {
                        Assert.AreEqual(field[i, j].Number, 2);
                    }
                }
            }

            Assert.IsTrue(field[2, 3].IsPopped);
        }

        [TestMethod]
        public void TestIfLetBalloonsFallMethodCorrectlyMovesTheBalloons()
        {
            var balloonsField = new GameModel().Field;
            this.gameLogicProvider.RandomizeBalloonField(balloonsField);

            var cloned = (IBalloon[,])balloonsField.Clone();

            for (int i = 0, j = 0; i < 5 && j < 10; i++, j++)
            {
                balloonsField[i, j].IsPopped = true;
            }

            this.gameLogicProvider.LetBalloonsFall(cloned);

            var areEqual = new QueriableMatrix<IBalloon>(balloonsField).Join(new QueriableMatrix<IBalloon>(cloned), x => x.IsPopped, y => y.IsPopped, (x, y) => !(x.IsPopped ^ y.IsPopped)).All(x => x);

            Assert.IsTrue(areEqual);
        }
    }
}