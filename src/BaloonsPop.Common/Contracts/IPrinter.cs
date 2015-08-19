namespace BaloonsPop.Common.Contracts
{
    public interface IPrinter
    {
        void PrintMessage(string message);

        void PrintField(byte[,] matrix);

        void PrintHighscore(string highscore);
    }
}