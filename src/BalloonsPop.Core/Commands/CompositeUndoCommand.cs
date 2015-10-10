namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class CompositeUndoCommand : CompositeCommand
    {
        public CompositeUndoCommand()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new UndoCommand(),
                new PrintFieldCommand()
            };
        }
    }
}
