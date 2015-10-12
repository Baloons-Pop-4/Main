namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Basic abstraction for a command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Abstract the routine for command execution in a given context.
        /// </summary>
        /// <param name="context">The context in which the concrete implementations execute.</param>
        void Execute(IContext context);
    }
}