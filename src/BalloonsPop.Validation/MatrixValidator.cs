namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Concrete implementation of the IMatrixValidator interface.
    /// </summary>
    public class MatrixValidator : IMatrixValidator
    {
        /// <summary>
        /// Returns true if a a point with the coordinates(zero-based) [row, col] is inside the provided matrix, and false otherwise.
        /// </summary>
        /// <typeparam name="T">Not constrainted.</typeparam>
        /// <param name="matrix">The matrix against which the coordinates will be checked.</param>
        /// <param name="row">The row part of the coordinates.</param>
        /// <param name="col">The column part of the coordiantes.</param>
        /// <returns></returns>
        public bool IsInsideMatrix<T>(T[,] matrix, int row, int col)
        {
            var rowIsInRange = IsInRange(0, matrix.GetLength(0), row);
            var colIsInRange = IsInRange(0, matrix.GetLength(1), col);

            return rowIsInRange && colIsInRange;
        }

        /// <summary>
        /// Returns true if an integer falls within a valid range.
        /// </summary>
        /// <param name="start">Start of the range(inclusive).</param>
        /// <param name="end">End of the range(not inclusive).</param>
        /// <param name="value">The value which is tested against the range.</param>
        /// <returns></returns>
        private static bool IsInRange(int start, int end, int value)
        {
            return start <= value && value < end;
        }
    }
}
