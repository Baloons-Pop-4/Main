namespace BalloonsPop.Engine.Commands
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