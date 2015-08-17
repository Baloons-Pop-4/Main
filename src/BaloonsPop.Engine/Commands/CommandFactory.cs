namespace BaloonsPop.Engine.Commands
{
    public class CommandFactory
    {
        public CommandFactory()
        {
        }

        public Command ExitCommand()
        {
            return new ExitCommand();
        }

        public Command RestartCommand(Game gameModel)
        {
            return new RestartCommand(gameModel);
        }

        public Command PrintFieldCommand(IPrinter printer, byte[,] field)
        {
            return new PrintFieldCommand(printer, field);
        }

        public Command PrintMessageCommand(IPrinter printer, string message)
        {
            return new PrintMessageCommand(printer, message);
        }
    }
}