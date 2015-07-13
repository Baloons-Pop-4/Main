// define all interface here

namespace Contracts
{
    public interface IEngine
    {
        void Run();
    }

    // The ILogger interface will be used to allow switching between different types of GUIss.
    public interface ILogger
    {
        void printMessage(string message);
        void printField(byte[,] matrix);
        void printHighscore(string highscore);
    }
}