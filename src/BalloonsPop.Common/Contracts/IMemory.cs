namespace BalloonsPop.Common.Contracts
{
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
        
        T GetItem();
    }
}