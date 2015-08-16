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

    // The IBalonsUserInterface will be used to allow switching between different types of GUIs.
    public interface IUserInputReader
    {
        string ReadUserInput();
    }

    public interface IBaloonsPrinter
    {
        void PrintMessage(string message);
        void PrintField(byte[,] matrix);
        void PrintHighscore(string highscore);
    }

    public interface IBaloonsUserInterface : IUserInputReader, IBaloonsPrinter
    {
    }
}