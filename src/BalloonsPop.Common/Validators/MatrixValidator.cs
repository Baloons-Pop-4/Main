namespace BalloonsPop.Common.Validators
{
    using BalloonsPop.Common.Contracts;

    public class MatrixValidator : IMatrixValidator
    {
        private static readonly MatrixValidator Instance = new MatrixValidator();

        private MatrixValidator()
        {
        }

        public static MatrixValidator GetInstance
        {
            get
            {
                return Instance;
            }
        }

        public bool IsInsideMatrix<T>(T[,] matrix, int row, int col)
        {
            var rowIsInRange = 0 <= row && row < matrix.GetLength(0);
            var colIsInRange = 0 <= col && col < matrix.GetLength(1);

            return rowIsInRange && colIsInRange;
        }
    }
}
