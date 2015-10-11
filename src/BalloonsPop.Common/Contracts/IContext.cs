namespace BalloonsPop.Common.Contracts
{
    public interface IContext
    {
        /// <summary>
        /// Gets a new game
        /// </summary>
        IGameModel Game { get; }

        /// <summary>
        /// Gets a LogicProvider
        /// </summary>
        IGameLogicProvider LogicProvider { get; }

        /// <summary>
        /// Gets a Printer
        /// </summary>
        IPrinter Printer { get; }

        /// <summary>
        /// Gets a Memento
        /// </summary>
        IStateSaver<IGameModel> Memento { get; }

        /// <summary>
        /// Gets a high score table
        /// </summary>
        IHighscoreTable HighscoreTable { get; }

        /// <summary>
        /// Gets a high score handling
        /// </summary>
        IHighscoreHandlingStrategy HighscoreHandling { get; }

        /// <summary>
        /// Gets an orchestra
        /// </summary>
        ISoundsPlayer Orchestra { get; }

        /// <summary>
        /// Gets or sets a message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets a player name
        /// </summary>
        string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets user's row
        /// </summary>
        int UserRow { get; set; }

        /// <summary>
        /// Gets or sets user's collumn
        /// </summary>
        int UserCol { get; set; }
    }
}
