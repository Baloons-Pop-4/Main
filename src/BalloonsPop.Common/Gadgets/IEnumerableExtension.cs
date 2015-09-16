namespace BalloonsPop.Common.Gadgets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// IEnumerable extensions to allow transforming linear collections into matrices
    /// </summary>
    public static class IEnumerableExtension
    {
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

        public static QueriableMatrix<T> ToQueriableMatrix<T>(this IEnumerable<T> collection, int rows, int columns)
        {
            // reuse code like a baws :D
            var matrix = collection.ToMatrix(rows, columns);
            var queriableMatrix = new QueriableMatrix<T>(matrix);

            return queriableMatrix;
        }

        //public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        //{
        //    foreach (var item in collection)
        //    {
        //        action(item);
        //    }
        //}
    
    }
}
