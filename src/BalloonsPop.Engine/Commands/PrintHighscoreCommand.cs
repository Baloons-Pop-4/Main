namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : ICommand
    {
        public PrintHighscoreCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Printer.PrintHighscore(new string[,] { { "mirishe", "mnogo" } });
        }
    }
}