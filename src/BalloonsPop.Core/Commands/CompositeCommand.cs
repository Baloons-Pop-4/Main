namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public abstract class CompositeCommand : ICommand
    {
        public IList<ICommand> SubCommands { get; protected set; }

        protected CompositeCommand()
        {
            this.SubCommands = new List<ICommand>();
        }

        protected CompositeCommand(IList<ICommand> predefinedCommands)
        {
            this.SubCommands = predefinedCommands;
        }

        public virtual void Execute(IContext context)
        {
            this.SubCommands.ForEach(cmd => cmd.Execute(context));
        }
    }
}
