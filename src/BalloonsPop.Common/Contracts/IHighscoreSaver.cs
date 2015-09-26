namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IHighscoreSaver
    {
        void Save(List<IPlayerScore> highscoreTable);
    }
}