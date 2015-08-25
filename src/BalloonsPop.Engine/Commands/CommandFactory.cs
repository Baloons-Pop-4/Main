namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public CommandFactory()
        {
        }

        public ICommand ExitCommand()
        {
            return new ExitCommand();
        }

        public ICommand RestartCommand(IGameModel gameModel)
        {
            return new RestartCommand(gameModel);
        }

        public ICommand PrintFieldCommand(IPrinter printer, byte[,] field)
        {
            return new PrintFieldCommand(printer, field);
        }

        public ICommand PrintMessageCommand(IPrinter printer, string message)
        {
            return new PrintMessageCommand(printer, message);
        }
        public ICommand PrintHighscoreCommand(IPrinter printer, string[,] chart)
        {
            return new PrintHighscoreCommand(printer, chart);
        }

        public ICommand PopBalloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col)
        {
            return new PopBalloonCommand(gameModel, gameLogicProvider, row, col);
        }
    }
}