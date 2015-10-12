namespace BalloonsPop.Saver.CloningStrategies
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides object cloning via System.Runtime.Serialization. The type of the object needs to be marked as serializable with the respective attribute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializationCloning<T> : ICloningStrategy<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationCloning{T}" /> class. 
        /// </summary>
        public SerializationCloning()
        {
        }

        /// <summary>
        /// Determines whether the object matches the strategy.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if the strategy matches, false otherwise.</returns>
        public bool IsMatch(T obj)
        {
            return typeof(T).IsSerializable;
        }

        /// <summary>
        /// Contes the provided object.
        /// </summary>
        /// <param name="obj">The object to be cloned.</param>
        /// <returns>A cloned object.</returns>
        public T Clone(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
