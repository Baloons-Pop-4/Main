namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class RestartCommand : GameCommand
    {
        private IGameLogicProvider gameLogicProvider;

        public RestartCommand(IGameModel gameModel, IGameLogicProvider gameLogicProvider)
            :base(gameModel)
        {
            this.gameLogicProvider = gameLogicProvider;
        }

        public override void Execute()
        {
            this.gameLogicProvider.RandomizeBaloonField(gameModel.Field);
        }
    }
}