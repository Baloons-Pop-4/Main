namespace BalloonsPop.Common.Gadgets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// IEnumerable extensions to allow transforming linear collections into matrices
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Projects the provided collection to a two-dimensional array with the provided row and column count.
        /// </summary>
        /// <typeparam name="T">The type of the resulting arrays elements.</typeparam>
        /// <param name="collection">The collection to be projected into a two-dimensional array.</param>
        /// <param name="rows">The count of the rows of the result.</param>
        /// <param name="columns">The counts of the columns of the result.</param>
        /// <returns>The collections projected into a two-dimensional array.</returns>
        public static T[,] ToMatrix<T>(this IEnumerable<T> collection, int rows, int columns)
        {
            var result = new T[rows, columns];

            var currentElementNumber = 0;

            foreach (var item in collection)
            {
                result[currentElementNumber / columns, currentElementNumber % columns] = item;
                currentElementNumber++;
            }

            return result;
        }

        /// <summary>
        /// Projects the provided collection into a new QueryableMatrix with the provided row and column count.
        /// </summary>
        /// <typeparam name="T">The type of the resulting QueryableMatrix.</typeparam>
        /// <param name="collection">The collection to be projected into a QueryableMatrix.</param>
        /// <param name="rows">The count of the rows of the QueryableMatrix.</param>
        /// <param name="columns">The counts of the columns of the QueryableMatrix.</param>
        /// <returns>The collections projected into a QueryableMatrix.</returns>
        public static QueryableMatrix<T> ToQueryableMatrix<T>(this IEnumerable<T> collection, int rows, int columns)
        {
            // reuse code like a baws :D
            var matrix = collection.ToMatrix(rows, columns);
            var queriableMatrix = new QueryableMatrix<T>(matrix);

            return queriableMatrix;
        }

        /// <summary>
        /// Performs an operation over each element of a collection using the foreach loop and returns the collection.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection over whose elements the provided action will be performed.</param>
        /// <param name="action">The action to perform over the collection's elements.</param>
        /// <returns>The same collection that was provided.</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
            {
                throw new NullReferenceException("Cannot foreach a null collection");
            }

            if (action == null)
            {
                throw new NullReferenceException("Cannot execute null method on a collection");
            }

            foreach (var item in collection)
            {
                action(item);
            }

            return collection;
        }
    }
}
