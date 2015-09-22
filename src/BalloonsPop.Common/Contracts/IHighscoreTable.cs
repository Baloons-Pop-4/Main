namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IHighscoreTable
    {
        List<PlayerScore> Table { get;  }

        bool CanAddPlayer(int movesCount);

        void AddPlayer(PlayerScore score);
    }
}
