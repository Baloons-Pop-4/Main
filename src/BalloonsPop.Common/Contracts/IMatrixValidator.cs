namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Abstracts validation for operations in a matrix.
    /// </summary>
    public interface IMatrixValidator
    {
        /// <summary>
        /// Abstract definition for a method that check if the provided set of coordinates falls within the provided matrix.
        /// </summary>
        /// <typeparam name="T">Type of the matrix's elements.</typeparam>
        /// <param name="matrix">The matrix to validate the coordinates agains.</param>
        /// <param name="row">The provided row coordinates.</param>
        /// <param name="col">The provided column coordinates.</param>
        /// <returns></returns>
        bool IsInsideMatrix<T>(T[,] matrix, int row, int col);
    }
}