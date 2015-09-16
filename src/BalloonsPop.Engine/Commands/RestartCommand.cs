namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class RestartCommand : GameCommand
    {
        private IGameLogicProvider logicProvider;

        public RestartCommand(IGameModel gameModel, IGameLogicProvider logicProvider)
            :base(gameModel)
        {
            this.logicProvider = logicProvider;
        }

        public override void Execute()
        {
            this.gameModel.Field = logicProvider.GenerateField();
            this.gameModel.ResetUserMoves();
        }
    }
}