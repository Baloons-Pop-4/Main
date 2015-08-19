namespace BaloonsPop.Common.Contracts
{
    public interface IMatrixValidator
    {
        bool IsInsideMatrix<T>(T[,] matrix, int row, int col);
    }
}