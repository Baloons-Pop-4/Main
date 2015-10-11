namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print field.
    /// </summary>
    public class PrintFieldCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintFieldCommand" /> class.
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