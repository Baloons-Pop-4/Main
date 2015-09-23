namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class RestartCommand : ICommand
    {
        public RestartCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Game.Field = context.LogicProvider.GenerateField();
            context.Game.ResetUserMoves();
        }
    }
}