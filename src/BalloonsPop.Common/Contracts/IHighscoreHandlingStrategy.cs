namespace BalloonsPop.Common.Contracts
{
    public interface IHighscoreHandlingStrategy
    {
        string FileName { get; }

        void Save(IHighscoreTable table);

        IHighscoreTable Load();
    }
}