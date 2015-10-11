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

        public bool IsMatch(T obj)
        {
            return obj as ICloneable != null;
        }

        public T Clone(T obj)
        {
            return (T)(obj as ICloneable).Clone();
        }
    }
}
