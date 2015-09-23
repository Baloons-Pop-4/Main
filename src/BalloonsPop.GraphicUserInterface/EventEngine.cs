namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core;

    public class EventEngine : EngineCore, IEventEngine
    {
        public EventEngine(
            IEventBasedUserInterface ui,
            IUserInputValidator validator,
            ICommandFactory commandFactory,
            IGameModel gameModel,
            IGameLogicProvider gameLogicProvider,
            IHighscoreTable scoreTable
            )
            : base(ui, validator, scoreTable, commandFactory, gameModel, gameLogicProvider)
        {
            ui.Raise += new EventHandler(this.HandleUserInput);
        }

        public void HandleUserInput(object sender, EventArgs e)
        {
            var castedArguments = e as ClickEventArgs;

            if (castedArguments == null)
            {
                throw new ArgumentException("Invalid event arguments are provided");
            }

            var commands = this.GetCommandList(castedArguments.CommandToPass);

            this.ExecuteCommandList(commands);
        }
    }
}
