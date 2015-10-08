namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class CompositeExitCommand : CompositeCommand
    {
        public CompositeExitCommand()
        {
            this.SubCommands = new List<ICommand>()
            {
                new SaveHighscoreCommand(),
                new ExitCommand()
            };
        }
    }
}
