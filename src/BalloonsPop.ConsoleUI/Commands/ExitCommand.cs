namespace BalloonsPop.Commands
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;

    /// <summary>
    /// Implements command for exit
    /// </summary>
    public class ExitCommand : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand" /> class.
        /// </summary>
        public ExitCommand()
            : base()
        {
            this.SubCommands.Add(new SaveHighscoreCommand());
        }

        /// <summary>
        /// Executes exit command
        /// </summary>
        /// <param name="context"></param>
        public override void Execute(IContext context)
        {
            base.Execute(context);
            Environment.Exit(0);
        }
    }
}
