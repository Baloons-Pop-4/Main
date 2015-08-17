namespace BaloonsPop.Engine.Commands
{
    public abstract class GameCommand : Command
    {
        protected IGameModel gameModel;

        public GameCommand(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }

    }
}
