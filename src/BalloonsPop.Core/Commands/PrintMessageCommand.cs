namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print a message.
    /// </summary>
    public class PrintMessageCommand : ICommand
    {
        /// <summary>
        /// The class constructor.
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