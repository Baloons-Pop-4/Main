namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to save game
    /// </summary>
    public class SaveCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCommand" /> class.
        /// </summary>
        public SaveCommand()
        {
        }

        /// <summary>
        /// Executes SaveCommand
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.Memento.SaveState(context.Game);
        }
    }
}