namespace BalloonsPop.Common.Contracts
{
    public interface ICommandFactory
    {
        ICommand RestartCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider);
        ICommand ExitCommand();
        ICommand PrintFieldCommand(IPrinter printer, IBaloonsField field);
        ICommand PrintMessageCommand(IPrinter printer, string message);
        ICommand PrintHighscoreCommand(IPrinter printer, string[,] chart);
        ICommand PopBaloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col, IPopPattern pattern);
    }
}