namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for a highscore handling strategy.
    /// </summary>
    public interface IHighscoreHandlingStrategy
    {
        /// <summary>
        /// Gets a file name.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Saves a high score table
        /// </summary>
        /// <param name="table">The highscore table to save in memory.</param>
        void Save(IHighscoreTable table);

        /// <summary>
        /// Abstract definition for loading a highscore table from memory.
        /// </summary>
        /// <returns>The loaded highscore table.</returns>
        IHighscoreTable Load();
    }
}