namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for memento memory and for the operation it supports.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMemory<T>
    {
        /// <summary>
        /// Gets a value indicating whether the memory is empty
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Pushes an item to the memory
        /// </summary>
        /// <param name="item"></param>
        void PushItem(T item);
        
        /// <summary>
        /// Abstract way to fetch an item from the memory.
        /// </summary>
        /// <returns>An element of type T contained in the memory.</returns>
        T GetItem();
    }
}