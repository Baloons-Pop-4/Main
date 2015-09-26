namespace BalloonsPop.Core.Memento.CloningStrategies
{
    /// <summary>
    /// The public interface for all implemented cloning routines.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICloningStrategy<T>
    {
        // here we have a really simple context, just the object itself
        bool IsMatch(T obj);
        T Clone(T obj);
    }
}