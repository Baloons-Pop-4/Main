namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    public class MatrixValidator : IMatrixValidator
    {
        public MatrixValidator()
        {
        }

        public bool IsInsideMatrix<T>(T[,] matrix, int row, int col)
        {
            var rowIsInRange = IsInRange(0, matrix.GetLength(0), row);
            var colIsInRange = IsInRange(0, matrix.GetLength(1), col);

            return rowIsInRange && colIsInRange;
        }

        private static bool IsInRange(int start, int end, int value)
        {
            return start <= value && value < end;
        }
    }
}
