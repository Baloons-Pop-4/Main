namespace Tests
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameLogicTests
    {
        private GameLogic gameLogicProvider;

        public GameLogicTests()
        {
            this.gameLogicProvider = new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator());
        }

        [TestMethod]
        public void TestIfGenerateFieldRetunrsAByteMatrixOfCorrectSize()
        {
            var field = new BaloonField();

            Assert.AreEqual(5, field.Rows);
            Assert.AreEqual(10, field.Columns);
        }

        [TestMethod]
        public void TestIfGenerateFieldReturnsFieldThatAreSignificantlyDifferentFromEachOther()
        {
            var baloonField = new BaloonField();
            var field1 = (byte[,])baloonField.Baloons.Clone();
            this.gameLogicProvider.RandomizeBaloonField(baloonField);
            var field2 = baloonField.Baloons;

            var differenceCount = 0;

            for (int i = 0; i < field1.GetLength(0); i++)
            {
                for (int k = 0; k < field1.GetLength(1); k++)
                {
                    if (field1[i, k] != field2[i, k])
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
                var field = new BaloonField();

                new GameLogic(null, new RandomNumberGenerator()).RandomizeBaloonField(field);

                foreach (var cell in field)
                {
                    if (cell <= 0 || 5 <= cell)
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsTrueWithAnEmptyField()
        {
            var sampleEmptyField = new BaloonField();
            Assert.IsTrue(this.gameLogicProvider.GameIsOver(sampleEmptyField));
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithANonemptyField()
        {
            var rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                var sampleEmptyField = new BaloonField();
                sampleEmptyField[rng.Next(0, 5), rng.Next(0, 10)] = (byte)rng.Next(1, 5);

                Assert.IsFalse(this.gameLogicProvider.GameIsOver(sampleEmptyField));
            }
        }

        [TestMethod]
        public void TestIfGameIsOverReturnsFalseWithFullField()
        {
            var field = new BaloonField();

            this.gameLogicProvider.RandomizeBaloonField(field);

            Assert.IsFalse(this.gameLogicProvider.GameIsOver(field));
        }

        [TestMethod]
        public void TestIfPopBalloonsPopsTheBaloonsOnTheSameRowAndColumn()
        {
            var field = new BaloonField();

            for (int i = 0, j = 5; i < 5; i++)
            {
                field[i, j] = (byte)1;
            }

            for (int i = 0, j = 2; i < 10; i++)
            {
                field[j, i] = (byte)1;
            }


            this.gameLogicProvider.PopBaloons(field, new Point(2,5), new DefaultPoppingPattern());

            foreach (var cell in field)
            {
                if (cell != 0)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestIfPopBalloonsPopsOnlyTheBaloonsOnTheSameRowAndColumn()
        {
            var field = new BaloonField();
            this.gameLogicProvider.RandomizeBaloonField(field);
            var storedField = (byte[,])field.Baloons.Clone();

            for (int i = 0, j = 5; i < 5; i++)
            {
                field[i, j] = (byte)1;
            }

            for (int i = 0, j = 2; i < 10; i++)
            {
                field[j, i] = (byte)1;
            }


            this.gameLogicProvider.PopBaloons(field, new Point(2,5), new DefaultPoppingPattern());


            for (int i = 0; i < storedField.GetLength(0); i++)
            {
                for (int j = 0; j < storedField.GetLength(1); j++)
                {
                    if (i == 2 || j == 5)
                    {
                        if (field[i, j] != 0)
                        {
                            Assert.Fail();
                        }
                    }
                    else
                    {
                        if (storedField[i, j] == 0)
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
            var field = new BaloonField();

            for (int i = 1; i < 4; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    field[i, j] = (byte)((i == 2 && j == 3) ? 1 : 2);
                }
            }


            this.gameLogicProvider.PopBaloons(field, new Point(2,3), new DefaultPoppingPattern());


            for (int i = 1; i < 4; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    if (i != 2 && j != 3)
                    {
                        Assert.AreEqual(field[i, j], 2);
                    }
                }
            }

            Assert.AreEqual(field[2, 3], 0);
        }
    }
}