namespace BalloonsPop.Common.Contracts
{
    public interface IMemory<T>
    {
        bool IsEmpty { get; }

        void PushItem(T item);
        
        T GetItem();
    }
}