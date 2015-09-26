namespace BalloonsPop.Core.Memento.CloningStrategies
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Provides object cloning via System.Runtime.Serialization. The type of the object needs to be marked as serializable with the respective attribute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializationCloning<T> : ICloningStrategy<T>
    {
        public SerializationCloning()
        {
        }

        public bool IsMatch(T obj)
        {
            return typeof(T).IsSerializable;
        }

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
