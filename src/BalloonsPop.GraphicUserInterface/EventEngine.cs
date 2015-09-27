namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Core;

    public class EventEngine : EngineCore, IEventEngine
    {
        public EventEngine(WpfBundle dependencyBundle)
            :base(dependencyBundle)
        {
            dependencyBundle.Gui.Raise += new EventHandler(this.HandleUserInput);
            this.context.Game.Field = this.context.LogicProvider.GenerateField();    
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
