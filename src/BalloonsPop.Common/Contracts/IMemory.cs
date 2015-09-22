namespace BalloonsPop.Common.Contracts
{
    public interface IMemory<T>
    {
        T GetItem();
        bool IsEmpty { get; }

        void PushItem(T item);
    }
}