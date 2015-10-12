namespace BalloonsPop.Common.Gadgets
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The wrapper class that serves as adapter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryableMatrix<T> : IEnumerable<T>
    {
        // Wrapping constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryableMatrix{T}" /> class.
        /// </summary>
        /// <param name="matrix"></param>
        public QueryableMatrix(T[,] matrix)
        {
            this.Value = matrix;
        }

        // Constructor for creating a new matrix and wrapping it automatically

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryableMatrix{T}" /> class.
        /// </summary>
        /// <param name="rows">The rows count of the new matrix.</param>
        /// <param name="cols">The column count of the new matrix.</param>
        public QueryableMatrix(int rows, int cols)
            : this(new T[rows, cols])
        {
        }

        // The actual matrix

        /// <summary>
        /// Gets or sets a generic value for the Queryable matrix
        /// </summary>
        public T[,] Value { get; set; }

        public T[][] TakeColumns()
        {
            var result = new T[this.Value.GetLength(1)][];

            for (int i = 0, columns = this.Value.GetLength(1); i < columns; i++)
            {
                result[i] = new T[this.Value.GetLength(0)];
                for (int j = 0, rows = this.Value.GetLength(0); j < rows; j++)
                {
                    result[i][j] = this.Value[j, i];
                }
            }

            return result;
        }

        // implementing this two methods from IEnumerable<T> part actually allows the client to use matrices with LINQ
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var field in this.Value)
            {
                yield return field;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}