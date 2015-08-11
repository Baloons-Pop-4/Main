// define all interface here

namespace Contracts
{
    public interface IEngine
    {
        void Run();
        void Initialize(ILogger logger);
    }

    // The ILogger interface will be used to allow switching between different types of GUIs.
    public interface ILogger
    {
        void PrintMessage(string message);
        void PrintField(byte[,] matrix);
        void PrintHighscore(string highscore);
    }
}