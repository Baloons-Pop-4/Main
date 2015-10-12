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
        /// <summary>
        /// Public constructor that initializes the instance with context and core dependency bundle.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="depBundle"></param>
        public GnomEngine(IContext ctx, ICoreBundle depBundle)
            : base(ctx, depBundle.UserInputValidator, depBundle.CommandFactory, depBundle.Logger)
        {
        }

        /// <summary>
        /// The method which handles user input by delegating user input to the core.
        /// </summary>
        public void HandleUserInput(string input)
        {
            var parsedCommand = this.GetCommand(input);

            parsedCommand.Execute(this.Context);
        }
    }
}
