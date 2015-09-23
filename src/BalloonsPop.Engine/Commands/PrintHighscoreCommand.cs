namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : ICommand
    {
        public PrintHighscoreCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Printer.PrintHighscore(context.HighscoreTable);
        }
    }
}