namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public class CompositeRestart : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeRestart" /> class.
        /// </summary>
        public CompositeRestart()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new SaveCommand(),
                new PrintHighscoreCommand(),
                new RestartCommand(),
                new PrintFieldCommand()
            };
        }
    }
}