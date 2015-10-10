namespace Tests
{
    using System;

    using BalloonsPop.Common.Gadgets;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QueriableMatrixTests
    {
        [TestMethod]
        public void TestIfValuePropertyReturnsTheSameMatrixItWasSetTo()
        {
            var matrix = new int[,] 
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            var queriableMatrix = new QueryableMatrix<int>(3, 4);

            queriableMatrix.Value = matrix;

            Assert.AreEqual(matrix, queriableMatrix.Value);
        }

        [TestMethod]
        public void TestIfForeachOnQueriableMatrixReturnsAllCells()
        {
            var matrix = new int[,] 
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            var queriableMatrix = new QueryableMatrix<int>(matrix);

            var counter = 1;

            foreach (var cell in queriableMatrix)
            {
                Assert.AreEqual(cell, counter++);
            }
        }

        [TestMethod]
        public void TestIfTakeColumnsMethodReturnAllColumnsCorrectlyAsJaggedArray()
        {
            var matrix = new int[,] 
            {
                { 1, 2, 3 },
                { 5, 6, 7 },
                { 9, 10, 11 }
            };

            var queriableMatrix = new QueryableMatrix<int>(matrix);

            var actual = queriableMatrix.TakeColumns();

            var expected = new int[][] 
            { 
                new int[] { 1, 5, 9 },
                new int[] { 2, 6, 10 }, 
                new int[] { 3, 7, 11 } 
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j]);
                }
            }
        }
    }
}