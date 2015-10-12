namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for a type that saves states of objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStateSaver<T>
    {
        /// <summary>
        /// Gets a value indicating whether the Saver has a state
        /// </summary>
        bool HasStates { get; }

        /// <summary>
        /// Saves the state of the Saver
        /// </summary>
        /// <param name="obj">The object who's current state will be saved.</param>
        void SaveState(T obj);

        /// <summary>
        /// Returns a saved state.
        /// </summary>
        /// <returns></returns>
        T GetState();
    }
}