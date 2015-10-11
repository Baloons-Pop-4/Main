namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print field.
    /// </summary>
    public class PrintFieldCommand : ICommand
    {
        /// <summary>
        /// The class constructor.
        /// </summary>
        public PrintFieldCommand()
        {
        }

        /// <summary>
        /// Executes PrintFieldCommand.
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.Printer.PrintField(context.Game.Field);
            context.Printer.PrintPlayerMoves(context.Game.UserMovesCount.ToString());
        }
    }
}