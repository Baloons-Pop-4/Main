namespace BalloonsPop.Core.Commands
{
    using System;

    using BalloonsPop.Common.Contracts;

    public class ExitCommand : ICommand
    {
        public ExitCommand()
        {
        }

        public void Execute(IContext context)
        {
            Environment.Exit(0);
        }
    }
}