namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides custom abstraction for objects that can clone themselves, returning an object of the same type as their own.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICloneableObject<T>
    {
        /// <summary>
        /// Abstraction for self-cloning.
        /// </summary>
        /// <returns></returns>
        T Clone();
    }
}