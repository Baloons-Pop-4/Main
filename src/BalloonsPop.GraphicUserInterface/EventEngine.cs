namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core;
    using System.Collections.Generic;

    public class EventEngine : EngineCore, IEventEngine
    {
        public EventEngine(WpfBundle dependencyBundle)
            :base(dependencyBundle)
        {
            dependencyBundle.Gui.Raise += new EventHandler(this.HandleUserInput);
            this.context.Game.Field = this.context.LogicProvider.GenerateField();    
        }

        //protected EventEngine(
        //    IEventBasedUserInterface ui,
        //    IUserInputValidator validator,
        //    ICommandFactory commandFactory,
        //    IGameModel gameModel,
        //    IGameLogicProvider gameLogicProvider,
        //    IHighscoreTable scoreTable,
        //    IHighscoreSaver saver
        //    )
        //    :base(ui, validator, scoreTable, saver, commandFactory, gameModel, gameLogicProvider)
        //{
        //    //ui.Raise += new EventHandler(this.HandleUserInput);
        //}

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
