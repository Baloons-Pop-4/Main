namespace BaloonsPop.Engine
{
    using System;
    using System.Collections.Generic;
    using BaloonsPop.Common.Contracts;

    public class GameLogic : IGameLogicProvider
    {
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 9;
        private const int MIN_BALOON_VALUE = 1;
        private const int MAX_BALOON_VALUE = 4;

        private static readonly Vector[] PopDirections = new Vector[] { new Vector(0, 1), new Vector(0, -1), new Vector(1, 0), new Vector(-1, 0) };

        private byte[,] field;

        private IRandomNumberGenerator randomNumberGenerator;

        private IMatrixValidator matrixValidator;

        public GameLogic(IMatrixValidator matrixValidator, IRandomNumberGenerator randomNumberGenerator)
        {
            this.matrixValidator = matrixValidator;
            this.randomNumberGenerator = randomNumberGenerator;
            this.field = new byte[FIELD_ROWS + 1, FIELD_COLS + 1];
        }

        public byte[,] GenerateField()
        {
            for (var row = 0; row <= FIELD_ROWS; row++)
            {
                for (var column = 0; column <= FIELD_COLS; column++)
                {
                    var currentBaloonValue = this.GetRandomBaloonValue();
                    this.field[row, column] = currentBaloonValue;
                }
            }

            return field;
        }

        public void PopBaloons(byte[,] field, int row, int column)
        {
            foreach (var dir in PopDirections)
            {
                this.PopInDirection(field, new Vector(row, column), dir);
            }

            field[row, column] = 0;
        }

        public void LetBaloonsFall(byte[,] field)
        {
            var baloonColumn = new Stack<byte>();

            for (int column = 0, length = field.GetLength(1); column < length; column++)
            {
                for (int row = 0, rowsCount = field.GetLength(0); row < rowsCount; row++)
                {
                    if (field[row, column] != 0)
                    {
                        baloonColumn.Push(field[row, column]);
                    }
                }

                for (int row = field.GetLength(0) - 1; row >= 0; row--)
                {
                    if (baloonColumn.Count > 0)
                    {
                        field[row, column] = baloonColumn.Pop();
                    }
                    else
                    {
                        field[row, column] = 0;
                    }
                }
            }
        }

        public bool GameIsOver(byte[,] matrix)
        {
            foreach (var cell in matrix)
            {
                if (cell != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void PopInDirection(byte[,] field, Vector point, Vector update)
        {
            var baloonType = field[point.X, point.Y];
            point = point + update;

            while (this.matrixValidator.IsInsideMatrix(field, point.X, point.Y) && field[point.X, point.Y] == baloonType)
            {
                field[point.X, point.Y] = 0;
                point = point + update;
            }
        }

        private byte GetRandomBaloonValue()
        {
            var randomBaloonValue = (byte)this.randomNumberGenerator.Next(MIN_BALOON_VALUE, MAX_BALOON_VALUE + 1);
            return randomBaloonValue;
        }
    }
}