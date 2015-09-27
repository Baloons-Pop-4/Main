namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// The public interface for all implemented cloning routines.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICloningStrategy<T>
    {
        /// <summary>
        /// Returns true if the strategy implementation is designed for the type of object passed.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsMatch(T obj);

        /// <summary>
        /// Deeply clones the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Clone(T obj);
    }
}