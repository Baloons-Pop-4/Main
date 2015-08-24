namespace BalloonsPop.Engine
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class GameLogic : IGameLogicProvider
    {
        //private const int FIELD_ROWS = 4;
        //private const int FIELD_COLS = 9;
        //private const int MIN_BALOON_VALUE = 1;
        //private const int MAX_BALOON_VALUE = 4;

        private const int MinBaloonValue = 1;

        private const int MaxBaloonValue = 4;

        private static readonly Vector[] PopDirections = new Vector[] { new Vector(0, 1), new Vector(0, -1), new Vector(1, 0), new Vector(-1, 0) };

        //private byte[,] field;

        private IRandomNumberGenerator randomNumberGenerator;

        private IMatrixValidator matrixValidator;

        public GameLogic(IMatrixValidator matrixValidator, IRandomNumberGenerator randomNumberGenerator)
        {
            this.matrixValidator = matrixValidator;
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public void RandomizeBaloonField(IBaloonsField field)
        {
            for (int i = 0, rowsCount = field.Rows; i < rowsCount; i++)
            {
                for (int j = 0, columnsCount = field.Columns; j < columnsCount; j++)
                {
                    field[i, j] = (byte)this.randomNumberGenerator.Next(MinBaloonValue, MaxBaloonValue + 1);

                }
            }
        }

        public void PopBaloons(IBaloonsField field, IPoint point, IPopPattern pattern)
        {
            foreach (var dir in pattern.Directions)
            {
                this.PopInDirection(field, (IPoint)point.Clone(), dir);
            }

            field[point] = 0;
        }

        public void LetBaloonsFall(IBaloonsField field)
        {
            var balloonColumn = new Stack<byte>();

            for (int column = 0, length = field.Columns; column < length; column++)
            {
                for (int row = 0, rowsCount = field.Rows; row < rowsCount; row++)
                {
                    if (field[row, column] != 0)
                    {
                        balloonColumn.Push(field[row, column]);
                    }
                }

                for (int row = field.Rows - 1; row >= 0; row--)
                {
                    if (balloonColumn.Count > 0)
                    {
                        field[row, column] = balloonColumn.Pop();
                    }
                    else
                    {
                        field[row, column] = 0;
                    }
                }
            }
        }

        public bool GameIsOver(IBaloonsField field)
        {
            foreach (var cell in field)
            {
                if (cell != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void PopInDirection(IBaloonsField field, IPoint point, IVector update)
        {
            var baloonType = field[point];
            point.Update(update);

            while (this.matrixValidator.IsInsideMatrix(field.Baloons, point.X, point.Y) && field[point] == baloonType)
            {
                field[point] = 0;
                point.Update(update);
            }
        }

    }
}