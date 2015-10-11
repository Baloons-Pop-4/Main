namespace BalloonsPop.ConsoleUserInterface
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core;

    /// <summary>
    /// Extends the EngineCore to compile with the application's gnomui interface.
    /// </summary>
    public class GnomEngine : EngineCore
    {
        public GnomEngine(IContext ctx, ICoreBundle depBundle)
            : base(ctx, depBundle.UserInputValidator, depBundle.CommandFactory, depBundle.Logger)
        {
        }

        /// <summary>
        /// The method which handles user input by delegating user input to the core.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments provided by the raiser.</param>
        public void HandleUserInput(string input)
        {
            var parsedCommand = this.GetCommandList(input);

            parsedCommand.Execute(this.Context);
        }
    }
}
