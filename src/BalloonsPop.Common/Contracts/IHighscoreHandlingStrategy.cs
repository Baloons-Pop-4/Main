namespace BalloonsPop.Common.Contracts
{
    public interface IHighscoreHandlingStrategy
    {
        void Save(IHighscoreTable table);

        IHighscoreTable Load();
    }
}