namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to print high score.
    /// </summary>
    public class PrintHighscoreCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintHighscoreCommand" /> class.
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