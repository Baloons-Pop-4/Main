namespace BalloonsPop.Saver.CloningStrategies
{
    using System;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides a custom implementation of cloning.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomCloning<T> : ICloningStrategy<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCloning{T}" /> class.
        /// </summary>
        public CustomCloning()
        {
        }

        public bool IsMatch(T obj)
        {
            return obj as ICloneableObject<T> != null;
        }

        public T Clone(T obj)
        {
            return (obj as ICloneableObject<T>).Clone();
        }
    }
}
