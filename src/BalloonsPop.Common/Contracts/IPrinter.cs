namespace BalloonsPop.Common.Contracts
{
    public interface IPrinter
    {
        void PrintMessage(string message);

        void PrintPlayerMoves(string moves);

        void PrintField(IBalloon[,] matrix);

        void PrintHighscore(IHighscoreTable table);
    }
}