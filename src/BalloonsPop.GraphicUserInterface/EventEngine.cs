namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Core;

    public class EventEngine : EngineCore
    {
        public EventEngine(WpfBundle dependencyBundle)
            : base(dependencyBundle)
        {
            dependencyBundle.Gui.Raise += new EventHandler(this.HandleUserInput);
            this.Context.Game.Field = this.Context.LogicProvider.GenerateField();    
        }

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
