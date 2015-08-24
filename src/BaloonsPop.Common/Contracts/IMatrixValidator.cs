﻿namespace BaloonsPop.Common.Contracts
{
    public interface IMatrixValidator
    {
        bool IsInsideMatrix(byte[,] matrix, int row, int col);
    }
}