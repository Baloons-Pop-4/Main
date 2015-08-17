namespace BaloonsPop.Engine
{
    public interface ICommandFactory
    {
        ICommand RestartCommand(Game gameModel);
        ICommand ExitCommand();
        ICommand PrintFieldCommand(IPrinter printer, byte[,] field);
        ICommand PrintMessageCommand(IPrinter printer, string message);
    }
}