namespace BalloonsPop.Common.Gadgets
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The wrapper class that serves as adapter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueriableMatrix<T> : IEnumerable<T>
    {
        // Wrapping constructor
        public QueriableMatrix(T[,] matrix)
        {
            this.Value = matrix;
        }

        // Constructor for creating a new matrix and wrapping it automatically
        public QueriableMatrix(int rows, int cols)
            : this(new T[rows, cols])
        {
        }

        // The actual matrix
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