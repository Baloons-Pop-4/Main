namespace BalloonsPop.Core.Memento.CloningStrategies
{
    using System;
    using System.Reflection;

    using BalloonsPop.Common.Contracts;

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

            var propertyList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var prop in propertyList)
            {
                if (prop.GetValue(copy, null) != prop.GetValue(obj, null))
                {
                    prop.SetValue(copy, prop.GetValue(obj, null), null);
                }
            }

            return copy;
        }
    }
}
