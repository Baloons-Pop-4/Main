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
            if(context.Memento.HasStates)
            {
                context.Game.Field = context.Memento.GetState().Field;
            }
        }
    }
}