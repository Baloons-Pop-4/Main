namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class CompositePopCommand : CompositeCommand
    {
        public CompositePopCommand()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new SaveCommand(),
                new PopBalloonCommand(),
                new GameOverHandlingCommand(),
                new PrintFieldCommand()
            };
        }
    }
}