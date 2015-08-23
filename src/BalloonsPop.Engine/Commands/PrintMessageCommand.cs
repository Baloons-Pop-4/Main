namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintMessageCommand : PrintCommands
    {
        private string message;

        public PrintMessageCommand(IPrinter printer, string message)
            :base(printer)
        {
            this.message = message;
        }

        public override void Execute()
        {
            this.printer.PrintMessage(this.message);
        }
    }
}