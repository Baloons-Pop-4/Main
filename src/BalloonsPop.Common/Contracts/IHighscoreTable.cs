namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IHighscoreTable
    {
        /// <summary>
        /// Gets a list of player scores
        /// </summary>
        List<PlayerScore> Table { get;  }

        bool CanAddPlayer(int movesCount);

        void AddPlayer(PlayerScore score);
    }
}
