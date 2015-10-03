namespace BalloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IHighscoreHandler
    {
        void Save(IHighscoreTable table);

        IHighscoreTable Load();
    }
}