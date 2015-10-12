namespace BalloonsPop.Saver.CloningStrategies
{
    using System;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides cloning via .NET's ICloneable interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DotNetCloning<T> : ICloningStrategy<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetCloning{T}" /> class. 
        /// </summary>
        public DotNetCloning()
        {
        }

        /// <summary>
        /// Determines whether the object matches the strategy.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the strategy matches, false otherwise.</returns>
        public bool IsMatch(T obj)
        {
            return obj as ICloneable != null;
        }

        /// <summary>
        /// Contes the provided object.
        /// </summary>
        /// <param name="obj">The object to be cloned.</param>
        /// <returns>A cloned object.</returns>
        public T Clone(T obj)
        {
            return (T)(obj as ICloneable).Clone();
        }
    }
}
