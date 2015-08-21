namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public class PrintHighscoreCommand : PrintCommands
    {
        private string[,] chart;

        private IPrinter printer;

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