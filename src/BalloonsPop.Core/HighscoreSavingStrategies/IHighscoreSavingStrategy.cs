namespace BalloonsPop.Core
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public interface IHighscoreSavingStrategy
    {
        void Save(List<PlayerScore> highscoreTable);
    }
}