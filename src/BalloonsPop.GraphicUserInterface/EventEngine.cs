namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Core;

    /// <summary>
    /// Extends the EngineCore to compile with the application's graphic interface.
    /// </summary>
    public class EventEngine : EngineCore
    {
        /// <summary>
        /// Public constructor that provides a wpf dependency bundle to the core.
        /// </summary>
        /// <param name="dependencyBundle">The bundle wrapping the core's dependencies.</param>
        public EventEngine(WpfBundle dependencyBundle)
            : base(dependencyBundle)
        {
            dependencyBundle.Gui.RaiseCommand += new EventHandler(this.HandleUserInput);
            this.Context.Game.Field = this.Context.LogicProvider.GenerateField();    
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

            var commands = this.GetCommandList(castedArguments.CommandToPass);

            this.ExecuteCommandList(commands);
        }
    }
}
