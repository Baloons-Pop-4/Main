namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class PopBalloonCommand : ICommand
    {
        public PopBalloonCommand() 
        {
        }

        public void Execute(IContext context)
        {
            context.LogicProvider.PopBalloons(context.Game.Field, context.UserRow, context.UserCol);
            context.LogicProvider.LetBalloonsFall(context.Game.Field);
            context.Game.IncrementMoves();
        }
    }
}