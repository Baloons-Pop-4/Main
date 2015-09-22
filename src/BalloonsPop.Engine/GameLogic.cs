namespace BalloonsPop.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class GameLogic : IGameLogicProvider
    {
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 9;
        private const int MIN_BALLOON_VALUE = 1;
        private const int MAX_BALLOON_VALUE = 4;

        private static readonly int[][] PopDirections = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        //private byte[,] field;

        private Random rng;

        private IMatrixValidator matrixValidator;

        public GameLogic(IMatrixValidator matrixValidator)
        {
            this.matrixValidator = matrixValidator;
            this.rng = new Random();
            // this.field = new byte[FIELD_ROWS + 1, FIELD_COLS + 1];
        }

        public IBalloon[,] GenerateField()
        {
            var field = new QueriableMatrix<IBalloon>(new IBalloon[FIELD_ROWS + 1, FIELD_COLS + 1])
                            .Select(x => this.GetRandomBalloonValue())
                            .ToMatrix(FIELD_ROWS + 1, FIELD_COLS + 1);

            //for (var row = 0; row <= FIELD_ROWS; row++)
            //{
            //    for (var column = 0; column <= FIELD_COLS; column++)
            //    {
            //        var currentBalloonValue = this.GetRandomBalloonValue();
            //        this.field[row, column] = currentBalloonValue;
            //    }
            //}

            return field;
        }

        public void PopBalloons(IBalloon[,] field, int row, int column)
        {
            foreach (var dir in PopDirections)
            {
                this.PopInDirection(field, row, column, dir[0], dir[1]);
            }

            // field[row, column] = 0;

            this.Pop(field[row, column]);
        }

        public void LetBalloonsFall(IBalloon[,] field)
        {
            var asColumns = new QueriableMatrix<IBalloon>(field)
                                        .TakeColumns()
                                        .Select(column => column.OrderBy(x => (x.isPopped ? -1 : 0)).ToArray())
                                        .ToArray();

            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    field[j, i] = asColumns[i][j];
                }
            }

            //for (int column = 0, length = field.GetLength(1); column < length; column++)
            //{
            //    for (int row = 0, rowsCount = field.GetLength(0); row < rowsCount; row++)
            //    {
            //        if (field[row, column] != 0)
            //        {
            //            balloonColumn.Push(field[row, column]);
            //        }
            //    }

            //    for (int row = field.GetLength(0) - 1; row >= 0; row--)
            //    {
            //        if (balloonColumn.Count > 0)
            //        {
            //            field[row, column] = balloonColumn.Pop();
            //        }
            //        else
            //        {
            //            field[row, column] = 0;
            //        }
            //    }
            //}
        }

        public bool GameIsOver(IBalloon[,] matrix)
        {
            var fieldIsEmpty = new QueriableMatrix<IBalloon>(matrix).All(balloon => balloon.isPopped);

            return fieldIsEmpty;
        }

        private void PopInDirection(IBalloon[,] field, int row, int col, int xUpdate, int yUpdate)
        {
            var balloonType = field[row, col];
            row += yUpdate;
            col += xUpdate;

            while (this.matrixValidator.IsInsideMatrix(field, row, col) && field[row, col].Number == balloonType.Number)
            {
                this.Pop(field[row, col]);
                row += yUpdate;
                col += xUpdate;
            }
        }

        private IBalloon GetRandomBalloonValue()
        {
            var randomBalloonValue = (byte)this.rng.Next(MIN_BALLOON_VALUE, MAX_BALLOON_VALUE + 1);
            return new Balloon() { Number = randomBalloonValue};
        }

        private void Pop(IBalloon balloon)
        {
            balloon.isPopped = true;
        }
    }
}