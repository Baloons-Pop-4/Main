namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : PrintCommands
    {
        private string[,] chart;

        public PrintHighscoreCommand(IPrinter printer, string[,] chart) 
            : base(printer)
        {
            this.chart = chart;
        }

        public override void Execute()
        {
            HighScoreUtility.SortAndPrintChartFive(this.chart);
        }
    }
}