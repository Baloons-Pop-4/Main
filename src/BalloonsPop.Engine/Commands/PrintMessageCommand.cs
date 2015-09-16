namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintMessageCommand : ICommand
    {
        public PrintMessageCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Printer.PrintMessage(context.Message);
        }
    }
}