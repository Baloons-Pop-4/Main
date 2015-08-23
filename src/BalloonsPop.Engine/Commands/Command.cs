namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public abstract class Command : ICommand
    {
        public Command()
        {
        }

        public abstract void Execute();
    }
}
