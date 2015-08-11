// define all interface here

namespace Contracts
{
    public interface IEngine
    {
        void Run();
        void Initialize(IBaloonsUserInterface UI);
    }

    // The ILogger interface will be used to allow switching between different types of GUIs.
    public interface IBaloonsUserInterface
    {
        void PrintMessage(string message);
        void PrintField(byte[,] matrix);
        void PrintHighscore(string highscore);
        string ReadUserInput();
    }
}