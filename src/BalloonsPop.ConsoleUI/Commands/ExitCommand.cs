namespace BalloonsPop.Commands
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;

    public class ExitCommand : CompositeCommand
    {
        public ExitCommand()
            : base()
        {
            this.SubCommands.Add(new SaveCommand());
        }

        public override void Execute(IContext context)
        {
            base.Execute(context);
            Environment.Exit(0);
        }
    }
}
