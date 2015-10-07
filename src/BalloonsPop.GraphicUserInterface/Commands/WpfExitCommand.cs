namespace BalloonsPop.GraphicUserInterface.Commands
{
    using System.Windows;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements the ICommand interface and provides exit functionality for a wpf application that can be called on by the engine.
    /// </summary>
    public class WpfExitCommand : ICommand
    {
        /// <summary>
        /// Executes the exit command in a provided context.
        /// </summary>
        /// <param name="context">The execution context for the command.</param>
        public void Execute(IContext context)
        {
            Application.Current.Shutdown(348944);
        }
    }
}
