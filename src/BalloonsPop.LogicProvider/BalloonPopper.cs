namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    /// <summary>
    /// Provides methods for popping ballons in a balloon field.
    /// </summary>
    internal class BalloonPopper : IBalloonPopper
    {
        private static readonly int[][] PopDirections = new int[][]
        { 
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };

        private readonly IMatrixValidator matrixValidator;

        /// <summary>
        /// Constructor for the BalloonPopper class.
        /// </summary>
        /// <param name="matrixValidator">An object that provides validations for matrix operations.</param>
        public BalloonPopper(IMatrixValidator matrixValidator)
        {
            this.matrixValidator = matrixValidator;
        }

        /// <summary>
        /// Pops the balloons on the same row and column that have the same color.
        /// </summary>
        /// <param name="field">The balloon field in which a ballon will be popped.</param>
        /// <param name="row">The zero-based number row of the ballon to be popped.</param>
        /// <param name="column">The zero-based number column of the ballon to be popped.</param>
        public void PopBalloons(IBalloon[,] field, int row, int column)
        {
            foreach (var dir in PopDirections)
            {
                this.PopInDirection(field, row, column, dir[0], dir[1]);
            }

            this.Pop(field[row, column]);
        }

        /// <summary>
        /// Lets the balloon fall to the "ground", simulating gravity.
        /// </summary>
        /// <param name="field">The balloon field in which the balloons will be let to fall.</param>
        public void LetBalloonsFall(IBalloon[,] field)
        {
            var asColumns = new QueriableMatrix<IBalloon>(field)
                                        .TakeColumns()
                                        .Select(column => column.OrderBy(x => (x.IsPopped ? -1 : 0)).ToArray())
                                        .ToArray();

            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    field[j, i] = asColumns[i][j];
                }
            }
        }

        private void PopInDirection(IBalloon[,] field, int row, int col, int horizontalUpdate, int verticalUpdate)
        {
            var balloonType = field[row, col];
            row += verticalUpdate;
            col += horizontalUpdate;

            while (this.matrixValidator.IsInsideMatrix(field, row, col) && field[row, col].Number == balloonType.Number)
            {
                this.Pop(field[row, col]);
                row += verticalUpdate;
                col += horizontalUpdate;
            }
        }

        private void Pop(IBalloon balloon)
        {
            balloon.IsPopped = true;
        }
    }
}
