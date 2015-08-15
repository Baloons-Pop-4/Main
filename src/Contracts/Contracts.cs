// define all interface here

namespace Contracts
{
    public interface IEngine
    {
        void Run();
        void Initialize(IBaloonsUserInterface UI, IUserInputValidator validator);
    }

    public interface IUserInputValidator
    {
        bool IsValidUserMove(string userInput);
    }

    // The ILogger interface will be used to allow switching between different types of GUIs.
    public interface IBaloonsUserInterface
    {
        void PrintMessage(string message);
        void PrintField(byte[,] matrix);
        void PrintHighscore(string highscore);
        string ReadUserInput();
    }

    public interface IMatrixValidator
    {
        bool IsInsideMatrix<T>(T[,] matrix, int row, int col);
    }
}