namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to save Highscore
    /// </summary>
    public class SaveHighscoreCommand : ICommand
    {
        /// <summary>
        /// Executes SaveHighscoreCommand
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.HighscoreHandling.Save(context.HighscoreTable);
        }
    }
}