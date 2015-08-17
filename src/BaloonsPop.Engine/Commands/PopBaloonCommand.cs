namespace BaloonsPop.Engine.Commands
{
    using Common.Validators;

    public class PopBaloonCommand : GameCommand
    {
        private IGameLogicProvider gameLogicProvider;

        private int row;

        private int col;

        public PopBaloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col) 
            : base(gameModel)
        {
            this.gameLogicProvider = gameLogicProvider;
            this.row = row;
            this.col = col;
        }

        public override void Execute()
        {
            this.gameLogicProvider.PopBaloons(this.gameModel.Field, this.row, this.col);
            this.gameLogicProvider.LetBaloonsFall(this.gameModel.Field);
            this.gameModel.IncrementMoves();
        }
    }
}