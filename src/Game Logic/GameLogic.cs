﻿namespace GameLogic
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

        public static void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0; checkLeft(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        public static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkRight(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        public static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkUp(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }

        public static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkDown(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

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

        public static bool doit(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }
                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }
    }
}