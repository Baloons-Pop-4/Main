namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class CompositePopCommand : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositePopCommand" /> class.
        /// </summary>
        public CompositePopCommand()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new SaveCommand(),
                new PopBalloonCommand(),
                new PlaySoundCommand("pop"),
                new GameOverHandlingCommand(),
                new PrintFieldCommand()
            };
        }
    }
}