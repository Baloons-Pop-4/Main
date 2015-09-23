namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintFieldCommand : ICommand
    {
        public PrintFieldCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Printer.PrintField(context.Game.Field);
        }
    }
}