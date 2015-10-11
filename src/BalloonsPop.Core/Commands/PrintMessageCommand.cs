namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print a message.
    /// </summary>
    public class PrintMessageCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintMessageCommand" /> class.
        /// </summary>
        public PrintMessageCommand()
        {
        }

        /// <summary>
        /// Executes PrintMessageCommand.
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(context.Message);
        }
    }
}