namespace BalloonsPop.Highscore
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public interface IHighscoreSavingStrategy
    {
        void Save(List<IPlayerScore> highscoreTable);
    }
}