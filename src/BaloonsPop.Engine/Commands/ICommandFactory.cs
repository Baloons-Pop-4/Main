namespace BaloonsPop.Engine
{
    public interface ICommandFactory
    {
        ICommand RestartCommand(IGameModel gameModel);
        ICommand ExitCommand();
        ICommand PrintFieldCommand(IPrinter printer, byte[,] field);
        ICommand PrintMessageCommand(IPrinter printer, string message);
    }
}