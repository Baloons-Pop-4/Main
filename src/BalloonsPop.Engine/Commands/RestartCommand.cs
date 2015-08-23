namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class RestartCommand : GameCommand
    {
        public RestartCommand(IGameModel gameModel)
            :base(gameModel)
        {
        }

        public override void Execute()
        {
            this.gameModel.Reset();
        }
    }
}