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
        private struct Vector
        {
            private int x;
            private int y;

            public int X
            {
                get
                {
                    return x;
                }
            }
            
            public int Y
            {
                get
                {
                    return y;
                }
            }

            public Vector(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public static Vector operator +(Vector left, Vector right)
            {
                var result = new Vector(left.X + right.X, left.Y + right.Y);
                return result;
            }
        }

        private static readonly Vector[] PopDirections = new Vector[]
        { 
            new Vector(0, 1),
            new Vector(0, -1),
            new Vector(-1, 0),
            new Vector(1, 0)
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
                this.PopInDirection(field, new Vector(column, row), dir);
            }

            field[row, column].IsPopped = true;
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

        private void PopInDirection(IBalloon[,] field, Vector point, Vector update)
        {
            var balloonType = field[point.Y, point.X];
            point += update;

            for (var p = point; this.matrixValidator.IsInsideMatrix(field, p.Y, p.X); p+=update)
            {
                if(field[p.Y, p.X].Number != balloonType.Number)
                {
                    break;
                }

                field[p.Y, p.X].IsPopped = true;
            }
        }
    }
}
