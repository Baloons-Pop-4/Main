namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements Undo command
    /// </summary>
    public class UndoCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndoCommand" /> class.
        /// </summary>
        public UndoCommand()
        {
        }

        /// <summary>
        /// Executes UndoCommand
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            if (context.Memento.HasStates)
            {
                context.Game.Field = context.Memento.GetState().Field;
            }
        }
    }
}