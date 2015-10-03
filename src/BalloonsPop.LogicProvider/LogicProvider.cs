namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;

    public class LogicProvider : IGameLogicProvider
    {
        private const int FieldRows = 4;
        private const int FieldCols = 9;
        private const int MinBalloonValue = 1;
        private const int MaxBalloonValue = 4;

        private static readonly int[][] PopDirections = new int[][]
        { 
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };
     
        private readonly IRandomNumberGenerator rng;

        private readonly IMatrixValidator matrixValidator;

        public LogicProvider(IMatrixValidator matrixValidator, IRandomNumberGenerator rng)
        {
            this.matrixValidator = matrixValidator;
            this.rng = rng;
        }

        public IBalloon[,] GenerateField()
        {
            var field = new QueriableMatrix<IBalloon>(new IBalloon[FieldRows + 1, FieldCols + 1])
                            .Select(x => this.GetRandomBalloonValue())
                            .ToMatrix(FieldRows + 1, FieldCols + 1);

            return field;
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

        private IBalloon GetRandomBalloonValue()
        {
            var randomBalloonValue = (byte)this.rng.Next(MinBalloonValue, MaxBalloonValue + 1);
            return new Balloon() { Number = randomBalloonValue };
        }

        private void Pop(IBalloon balloon)
        {
            balloon.IsPopped = true;
        }
    }
}