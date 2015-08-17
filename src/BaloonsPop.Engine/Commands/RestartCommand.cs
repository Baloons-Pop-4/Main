namespace BaloonsPop.Engine.Commands
{
    public class RestartCommand : GameCommand
    {
        public RestartCommand(Game gameModel)
            :base(gameModel)
        {
        }

        public override void Execute()
        {
            this.gameModel.Reset();
        }
    }
}