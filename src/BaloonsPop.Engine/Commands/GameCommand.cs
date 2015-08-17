namespace BaloonsPop.Engine.Commands
{
    public abstract class GameCommand : Command
    {
        protected Game gameModel;

        public GameCommand(Game gameModel)
        {
            this.gameModel = gameModel;
        }

    }
}
