namespace BalloonsPop.Engine.Commands
{
    using BalloonsPop.Common.Contracts;

    public class UndoCommand : ICommand
    {
        public UndoCommand()
        {
        }

        public void Execute(IContext context)
        {
            context.Game.Field = context.Memento.State.Field;
        }
    }
}