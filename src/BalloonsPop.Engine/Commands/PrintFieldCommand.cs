namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PrintFieldCommand : PrintCommands
    {
        private IGameModel game;

        public PrintFieldCommand(IPrinter printer, IGameModel game)
            :base(printer)
        {
            this.game = game;
        }

        public override void Execute()
        {
            this.printer.PrintField(game.Field);
        }
    }
}