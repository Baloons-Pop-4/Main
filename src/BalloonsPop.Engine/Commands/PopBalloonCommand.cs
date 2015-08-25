namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PopBalloonCommand : GameCommand
    {
        private IGameLogicProvider gameLogicProvider;

        private int row;

        private int col;

        public PopBalloonCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider, int row, int col) 
            : base(gameModel)
        {
            this.gameLogicProvider = gameLogicProvider;
            this.row = row;
            this.col = col;
        }

        public override void Execute()
        {
            this.gameLogicProvider.PopBalloons(this.gameModel.Field, this.row, this.col);
            this.gameLogicProvider.LetBalloonsFall(this.gameModel.Field);
            this.gameModel.IncrementMoves();
        }
    }
}