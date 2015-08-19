namespace BaloonsPop.Engine.Commands
{
    public abstract class Command : ICommand
    {
        public Command()
        {
        }

        public abstract void Execute();
    }
}
