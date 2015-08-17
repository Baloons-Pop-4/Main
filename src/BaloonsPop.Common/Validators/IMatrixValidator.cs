namespace BaloonsPop.Common.Validators
{
    public interface IMatrixValidator
    {
        bool IsInsideMatrix<T>(T[,] matrix, int row, int col);
    }
}