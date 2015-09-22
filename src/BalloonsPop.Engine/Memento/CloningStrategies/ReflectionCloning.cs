namespace BalloonsPop.Engine.Memento.CloningStrategies
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Provides object cloning via System.Reflection. The cloned type has to provide a parameterless constructor and setters for all properties.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReflectionCloning<T> : ICloningStrategy<T>
    {
        public ReflectionCloning()
        {
        }

        public bool IsMatch(T obj)
        {
            return typeof(T).GetConstructor(Type.EmptyTypes) != null;
        }

        public T Clone(T obj)
        {
            var copy = Activator.CreateInstance<T>();

            var piList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var pi in piList)
            {
                if (pi.GetValue(copy, null) != pi.GetValue(obj, null))
                {
                    pi.SetValue(copy, pi.GetValue(obj, null), null);
                }

            }

            return copy;
        }
    }
}
