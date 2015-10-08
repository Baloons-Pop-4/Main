namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class CompositeRestart : CompositeCommand
    {
        public CompositeRestart()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new SaveCommand(),
                new RestartCommand(),
                new PrintFieldCommand()
            };
        }
    }
}