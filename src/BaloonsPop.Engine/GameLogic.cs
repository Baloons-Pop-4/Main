﻿namespace BaloonsPop.Engine
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

        private static readonly int[][] PopDirections = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        private byte[,] field;

        private Random rng;

        private IMatrixValidator matrixValidator;

        public GameLogic(IMatrixValidator matrixValidator)
        {
            this.matrixValidator = matrixValidator;
            this.rng = new Random();
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
                this.PopInDirection(field, row, column, dir[0], dir[1]);
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

        private void PopInDirection(byte[,] field, int row, int col, int xUpdate, int yUpdate)
        {
            var baloonType = field[row, col];
            row += yUpdate;
            col += xUpdate;

            while (this.matrixValidator.IsInsideMatrix(field, row, col) && field[row, col] == baloonType)
            {
                field[row, col] = 0;
                row += yUpdate;
                col += xUpdate;
            }
        }

        private byte GetRandomBaloonValue()
        {
            var randomBaloonValue = (byte)this.rng.Next(MIN_BALOON_VALUE, MAX_BALOON_VALUE + 1);
            return randomBaloonValue;
        }
    }
}