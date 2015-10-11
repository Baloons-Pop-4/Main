namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public abstract class CompositeCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeCommand" /> class.
        /// </summary>
        protected CompositeCommand()
        {
            this.SubCommands = new List<ICommand>();
        }

        /// <summary>
        /// Gets or sets a list of Subcommands
        /// </summary>
        public IList<ICommand> SubCommands { get; protected set; }

        public virtual void Execute(IContext context)
        {
            this.SubCommands.ForEach(cmd => cmd.Execute(context));
        }
    }
}
