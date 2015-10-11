namespace BalloonsPop.Common.Contracts
{
    public interface IHighscoreHandlingStrategy
    {
        /// <summary>
        /// Gets a file name.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Saves a high score table
        /// </summary>
        /// <param name="table"></param>
        void Save(IHighscoreTable table);

        IHighscoreTable Load();
    }
}