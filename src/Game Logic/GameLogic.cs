namespace GameLogic
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class GameLogic
    {
        private const int FIELD_ROWS = 4;
        private const int FIELD_COLS = 9;
        private const int MIN_BALOON_VALUE = 1;
        private const int MAX_BALOON_VALUE = 4;

        private static readonly int[][] popDirections = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        private Random rng;

        private IMatrixValidator matrixValidator;

        public GameLogic(IMatrixValidator matrixValidator)
        {
            this.matrixValidator = matrixValidator;
            this.rng = new Random();
        }

        public byte[,] GenerateField()
        {
            var newField = new byte[FIELD_ROWS + 1, FIELD_COLS + 1];

            for (var row = 0; row <= FIELD_ROWS; row++)
            {
                for (var column = 0; column <= FIELD_COLS; column++)
                {
                    var cellValue = (byte)this.rng.Next(MIN_BALOON_VALUE, MAX_BALOON_VALUE + 1);
                    newField[row, column] = cellValue;
                }
            }

            return newField;
        }
        
        public void PopInDirection(byte[,] matrix, int row, int col, int xUpdate, int yUpdate)
        {
            var baloonType = matrix[row, col];
            row += yUpdate;
            col += xUpdate;

            while (this.matrixValidator.IsInsideMatrix(matrix, row, col) && matrix[row, col] == baloonType)
            {
                matrix[row, col] = 0;
                row += yUpdate;
                col += xUpdate;
            } 
        }

        public void PopBaloons(byte[,] baloonField, int row, int column)
        {
            if (baloonField[row, column] == 0)
            {
                return;
            }

            foreach (var dir in popDirections)
            {
                PopInDirection(baloonField, row, column, dir[0], dir[1]);
            }

            baloonField[row, column] = 0;
        }

        public void LetBaloonsFall(byte[,] baloonField)
        {
            var baloonColumn = new Stack<byte>();

            for (int column = 0, length = baloonField.GetLength(1); column < length; column++)
            {
                for (int row = 0, rowsCount = baloonField.GetLength(0); row < rowsCount; row++)
                {
                    if(baloonField[row, column] != 0)
                    {
                        baloonColumn.Push(baloonField[row, column]);
                    }
                }

                for (int row = baloonField.GetLength(0) - 1; row >= 0; row--)
                {
                    if(baloonColumn.Count > 0)
                    {
                        baloonField[row, column] = baloonColumn.Pop();
                    }
                    else
                    {
                        baloonField[row, column] = 0;
                    }
                    
                }
            }
        }

        public bool GameIsOver(byte[,] matrix)
        {
            foreach (var cell in matrix)
            {
                if(cell != 0)
                {
                    return false;
                }
            }

            return true;

            //bool isWinner = true;
            //Stack<byte> stek = new Stack<byte>();
            //int columnLenght = matrix.GetLength(0);
            //for (int j = 0; j < matrix.GetLength(1); j++)
            //{
            //    for (int i = 0; i < columnLenght; i++)
            //    {
            //        if (matrix[i, j] != 0)
            //        {
            //            isWinner = false;
            //            stek.Push(matrix[i, j]);
            //        }
            //    }
            //    for (int k = columnLenght - 1; (k >= 0); k--)
            //    {
            //        try
            //        {
            //            matrix[k, j] = stek.Pop();
            //        }
            //        catch (Exception)
            //        {
            //            matrix[k, j] = 0;
            //        }
            //    }
            //}
            //return isWinner;
        }
    }
}