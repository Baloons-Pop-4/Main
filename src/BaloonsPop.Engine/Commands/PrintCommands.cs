namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public abstract class PrintCommands : Command
    {
        protected IPrinter printer;

        public PrintCommands(IPrinter printer)
        {
            this.printer = printer;
        }
    }
}
