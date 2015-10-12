namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// An abstract structure that tracks player rankings.
    /// </summary>
    public interface IHighscoreTable
    {
        /// <summary>
        /// Gets a list of player scores
        /// </summary>
        List<PlayerScore> Table { get;  }

        /// <summary>
        /// Checks whether another player's score can be added to the current implementation instance.
        /// </summary>
        /// <param name="movesCount">The score of the player</param>
        /// <returns>True if the player can be added to the table, false otherwise.</returns>
        bool CanAddPlayer(int movesCount);

        /// <summary>
        /// Abstraction of the addition of new player scores to the table
        /// </summary>
        /// <param name="score">The score to add to the table.</param>
        void AddPlayer(PlayerScore score);
    }
}
