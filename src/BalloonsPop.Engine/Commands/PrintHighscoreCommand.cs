namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : PrintCommands
    {
        private string[,] chart;

        public PrintHighscoreCommand(IPrinter printer, string[,] chart) 
            : base(printer)
        {
            this.chart = chart;
            this.printer = printer;
        }

        public override void Execute()
        {
            this.printer.PrintHighscore(this.chart);
        }
    }
}