namespace BaloonsPop.Engine.Commands
{
    using BaloonsPop.Common.Contracts;

    public class PopBaloonCommand : GameCommand
    {
        private IGameLogicProvider gameLogicProvider;

        private int row;

        private int col;

        private IPopPattern pattern;

        public PopBaloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col, IPopPattern pattern) : base(gameModel)
        {
            this.pattern = pattern;
            this.gameLogicProvider = gameLogicProvider;
            this.row = row;
            this.col = col;
        }

        public override void Execute()
        {
            this.gameLogicProvider.PopBaloons(this.gameModel.Field, new Point(this.row, this.col), this.pattern);
            this.gameLogicProvider.LetBaloonsFall(this.gameModel.Field);
            this.gameModel.IncrementMoves();
        }
    }
}