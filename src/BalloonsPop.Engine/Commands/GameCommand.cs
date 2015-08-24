namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public abstract class GameCommand : Command
    {
        protected IGameModel gameModel;

        public GameCommand(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }
    }
}