namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print Highscore.
    /// </summary>
    public class PrintHighscoreCommand : ICommand
    {
        /// <summary>
        /// The class constructor.
        /// </summary>
        public PrintHighscoreCommand()
        {
        }

        /// <summary>
        /// Executes PrintHighscoreCommand.
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.Printer.PrintHighscore(context.HighscoreTable);
        }
    }
}