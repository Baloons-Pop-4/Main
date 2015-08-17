namespace BaloonsPop.Engine.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public CommandFactory()
        {
        }

        public ICommand ExitCommand()
        {
            return new ExitCommand();
        }

        public ICommand RestartCommand(Game gameModel)
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
    }
}