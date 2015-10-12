namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Windows.Controls;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core;

    /// <summary>
    /// Extends the EngineCore to compile with the application's graphic interface.
    /// </summary>
    public class EventEngine : EngineCore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventEngine" /> class.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="depBundle"></param>
        public EventEngine(IContext ctx, WpfBundle depBundle)
            : base(ctx, depBundle.UserInputValidator, depBundle.CommandFactory, depBundle.Logger)
        {
            depBundle.Gui.RaiseCommand += this.HandleUserInput;
            depBundle.Gui.ChangedUserName += this.SetPlayerNameInContext;
        }

        /// <summary>
        /// The method which handles user input by delegating events in compatible form to the core.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments provided by the raiser.</param>
        public void HandleUserInput(object sender, EventArgs e)
        {
            var castedArguments = e as UserCommandArgs;

            if (castedArguments == null)
            {
                throw new ArgumentException("Invalid event arguments are provided");
            }

            var parsedCommand = this.GetCommand(castedArguments.CommandToPass);

            parsedCommand.Execute(this.Context);
        }

        /// <summary>
        /// Sets the player name in the context when it is changed in the view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetPlayerNameInContext(object sender, EventArgs e)
        {
            this.Context.PlayerName = (sender as TextBox).Text;
        }
    }
}
