namespace BalloonsPop.Common.Contracts
{
    public interface IPrinter
    {
        void PrintMessage(string message);

        void PrintField(IBalloon[,] matrix);

        void PrintHighscore(string[,] highscore);
    }
}