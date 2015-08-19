namespace BaloonsPop.Engine.Commands
{
    public abstract class PrintCommands : Command
    {
        protected IPrinter printer;

        public PrintCommands(IPrinter printer)
        {
            this.printer = printer;
        }
    }
}
