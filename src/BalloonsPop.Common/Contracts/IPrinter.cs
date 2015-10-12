namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for an object type that supports printing operations.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Abstraction for message printing.
        /// </summary>
        /// <param name="message">The message to be printed.</param>
        void PrintMessage(string message);

        /// <summary>
        /// Abstraction for player moves count printing.
        /// </summary>
        /// <param name="moves">The moves to be printed.</param>
        void PrintPlayerMoves(string moves);

        /// <summary>
        /// Abstraction for printing a balloon field.
        /// </summary>
        /// <param name="matrix">The field to be printed.</param>
        void PrintField(IBalloon[,] matrix);

        /// <summary>
        /// Abstraction for printing a highscore table.
        /// </summary>
        /// <param name="table">The table to be printed.</param>
        void PrintHighscore(IHighscoreTable table);
    }
}