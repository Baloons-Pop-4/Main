namespace Tests
{
    using System;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Common.Contracts;
    using System.Linq;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Memento;

    using BalloonsPop.LogicProvider;
    using BalloonsPop.GameModels;

    [TestClass]
    public class GameLogicTests
    {
        private LogicProvider gameLogicProvider;

        public GameLogicTests()
        {
            this.gameLogicProvider = new LogicProvider(new MatrixValidator(), new RandomNumberGenerator());
        }

        [TestMethod]
        public void TestIfGenerateFieldReturnAByteMatrix()
        {
            var field = this.gameLogicProvider.GenerateField();
            Assert.AreEqual(typeof(IBalloon[,]), field.GetType());
        }

        [TestMethod]
        public void TestIfGenerateFieldRetunrsAByteMatrixOfCorrectSize()
        {
            var field = this.gameLogicProvider.GenerateField();

            Assert.AreEqual(5, field.GetLength(0));
            Assert.AreEqual(10, field.GetLength(1));
        }

        [TestMethod]
        public void TestIfGenerateFieldReturnsFieldThatAreSignificantlyDifferentFromEachOther()
        {
            var field1 = (IBalloon[,])this.gameLogicProvider.GenerateField().Clone();
            var field2 = this.gameLogicProvider.GenerateField();

            var differenceCount = 0;

            for (int i = 0; i < field1.GetLength(0); i++)
            {
                for (int k = 0; k < field1.GetLength(1); k++)
                {
                    if (field1[i, k].Number != field2[i, k].Number)
                    {
                        differenceCount++;
                    }
                }
            }

            var numberOfCells = field1.GetLength(0) * field1.GetLength(1);

            Assert.IsTrue(differenceCount > numberOfCells / 3);
        }

        [TestMethod]
        public void TestIfGenerateFieldInitializesTheFieldWithCorrectBalloonValues()
        {
            for (int i = 0; i < 10; i++)
            {
                var field = this.gameLogicProvider.GenerateField();

                foreach (var cell in field)
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
            var sampleEmptyField = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon() { IsPopped = true}).ToMatrix(5, 10);
            Assert.IsTrue(this.gameLogicProvider.GameIsOver(sampleEmptyField));
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithANonemptyField()
        {
            var rng = new Random();
            var sampleEmptyField = new QueriableMatrix<byte>(5, 10).Select(x => new Balloon()).ToMatrix(5, 10);
            for (int i = 0; i < 50; i++)
            {
                
                sampleEmptyField[rng.Next(0, 5), rng.Next(0, 10)] = new Balloon() { Number = (byte)rng.Next(1, 5)};

                Assert.IsFalse(this.gameLogicProvider.GameIsOver(sampleEmptyField));
            }
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithFullField()
        {
            var field = this.gameLogicProvider.GenerateField();

            Assert.IsFalse(this.gameLogicProvider.GameIsOver(field));
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
            game.Field = this.gameLogicProvider.GenerateField();
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
            var balloonsField = this.gameLogicProvider.GenerateField();

            var cloned = (IBalloon[,])balloonsField.Clone();

            for (int i = 0, j = 0; i < 5 && j < 10; i++, j++)
            {
                balloonsField[i, j].IsPopped = true;
            }

            gameLogicProvider.LetBalloonsFall(cloned);

            var areEqual = new QueriableMatrix<IBalloon>(balloonsField).Join(new QueriableMatrix<IBalloon>(cloned), x => x.IsPopped, y => y.IsPopped, (x, y) => !(x.IsPopped ^ y.IsPopped)).All(x => x);

            Assert.IsTrue(areEqual);
        }
    }
}