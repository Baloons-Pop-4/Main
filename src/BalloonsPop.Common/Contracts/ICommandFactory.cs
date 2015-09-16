namespace BalloonsPop.Common.Contracts
{
    public interface ICommandFactory
    {
        //ICommand RestartCommand(IGameModel gameModel, IGameLogicProvider logicProvider);
        //ICommand ExitCommand();
        //ICommand PrintFieldCommand(IPrinter printer, IGameModel game);
        //ICommand PrintMessageCommand(IPrinter printer, string message);
        //ICommand PrintHighscoreCommand(IPrinter printer, string[,] chart);
        //ICommand PopBalloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col);
        ICommand CreateCommand(string commandName);
    }
}