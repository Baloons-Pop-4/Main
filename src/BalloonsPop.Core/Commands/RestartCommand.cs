namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to restart the game
    /// </summary>
    public class RestartCommand : ICommand
    {
        /// <summary>
        /// Executes RestartCommand
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IContext context)
        {
            context.LogicProvider.RandomizeBalloonField(context.Game.Field);
            context.Game.ResetUserMoves();

            if (context.Memento != null)
            {
                while (context.Memento.HasStates)
                {
                    context.Memento.GetState();
                }
            }
        }
    }
}