namespace BalloonsPop.Engine.Memento
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Common.Contracts;

    public class Memento<T> : IMemento<T>
    {
        private T state;

        public Memento()
        {
        }

        public Memento(T currentState)
        {
            this.State = currentState;
        }

        public T State
        {
            get
            {
                return this.DeepClone(this.state);
            }
            set
            {
                this.state = this.DeepClone(value);
            }
        }

        private T DeepClone(T obj)
        {
            T result = default(T);

            new Switch<T>(obj)
                .Case(obj as ICloneableObject<T> != null, () =>
                {
                    result = (obj as ICloneableObject<T>).Clone();
                })
                .Case(obj as ICloneable != null, () =>
                {
                    result = (T)(obj as ICloneable).Clone();
                })
                .Default(() =>
                {
                    using (var ms = new MemoryStream())
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(ms, obj);
                        ms.Position = 0;

                        result = (T)formatter.Deserialize(ms);
                    }
                });

            return result;
        }
    }
}
