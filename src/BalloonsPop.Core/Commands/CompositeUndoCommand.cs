namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class CompositeUndoCommand : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeUndoCommand" /> class.
        /// </summary>
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
