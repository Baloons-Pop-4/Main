namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class SaveHighscoreCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.HighscoreHandling.Save(context.HighscoreTable);
        }
    }
}