namespace BalloonsPop.Common.Contracts
{
    public interface IStateSaver<T>
    {
        /// <summary>
        /// Gets a value indicating whether the Saver has a state
        /// </summary>
        bool HasStates { get; }

        /// <summary>
        /// Saves the state of the Saver
        /// </summary>
        /// <param name="obj"></param>
        void SaveState(T obj);

        T GetState();
    }
}