namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IHighscoreTable
    {
        List<IPlayerScore> Table { get;  }

        bool CanAddPlayer(int movesCount);

        void AddPlayer(IPlayerScore score);
    }
}
