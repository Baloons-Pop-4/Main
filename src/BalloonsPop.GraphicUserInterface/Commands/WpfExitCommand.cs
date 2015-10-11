namespace BalloonsPop.GraphicUserInterface.Commands
{
    using System.Windows;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;

    /// <summary>
    /// Implements the ICommand interface and provides exit functionality for a wpf application that can be called on by the engine.
    /// </summary>
    public class WpfExitCommand : CompositeCommand
    {
        private const int WpfExitCode = 348944;

        public WpfExitCommand()
            : base()
        {
            this.SubCommands.Add(new SaveHighscoreCommand());
        }

        /// <summary>
        /// Executes the exit command in a provided context.
        /// </summary>
        /// <param name="context">The execution context for the command.</param>
        public override void Execute(IContext context)
        {
            Application.Current.Shutdown(WpfExitCode);
            base.Execute(context);
        }
    }
}
