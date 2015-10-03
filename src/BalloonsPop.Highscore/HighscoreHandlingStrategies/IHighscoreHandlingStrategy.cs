namespace BalloonsPop.Highscore.HighscoreHandlingStrategies
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public interface IHighscoreHandlingStrategy
    {
        void Save(IHighscoreTable table);

        IHighscoreTable Load();
    }
}