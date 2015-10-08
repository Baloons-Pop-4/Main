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
