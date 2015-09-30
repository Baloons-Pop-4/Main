namespace BalloonsPop.Common.Contracts
{
    public interface IStateSaver<T>
    {
        bool HasStates { get; }

        void SaveState(T obj);

        T GetState();
    }
}