namespace BalloonsPop.Engine.Commands
{
    using System;

    public class ExitCommand : Command
    {
        public ExitCommand()
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}