namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

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

        public BalloonPopper(IMatrixValidator matrixValidator)
        {
            this.matrixValidator = matrixValidator;
        }

        public void PopBalloons(IBalloon[,] field, int row, int column)
        {
            foreach (var dir in PopDirections)
            {
                this.PopInDirection(field, row, column, dir[0], dir[1]);
            }

            this.Pop(field[row, column]);
        }

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

        public bool GameIsOver(IBalloon[,] matrix)
        {
            var fieldIsEmpty = new QueriableMatrix<IBalloon>(matrix).All(balloon => balloon.IsPopped);

            return fieldIsEmpty;
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
