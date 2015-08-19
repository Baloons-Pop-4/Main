namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public abstract class Command : ICommand
    {
        public Command()
        {
        }

        public abstract void Execute();
    }
}
