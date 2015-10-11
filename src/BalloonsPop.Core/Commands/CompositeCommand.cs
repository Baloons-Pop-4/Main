namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public abstract class CompositeCommand : ICommand
    {
        protected CompositeCommand()
        {
            this.SubCommands = new List<ICommand>();
        }

        public IList<ICommand> SubCommands { get; protected set; }

        public virtual void Execute(IContext context)
        {
            this.SubCommands.ForEach(cmd => cmd.Execute(context));
        }
    }
}
