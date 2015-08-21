using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaloonsPop.GraphicUserInterface
{
    using BaloonsPop.Common.Contracts;
    using BaloonsPop.Engine;

    public class GraphicEngine : Engine, IGraphicEngine
    {
        public GraphicEngine(IEventBasedUserInterface ui, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider) 
            : base(ui, validator, commandFactory, gameModel, gameLogicProvider)
        {
            ui.Raise += new EventHandler(this.HandleUserInput);
        }

        public void HandleUserInput(object sender, EventArgs e)
        {
            var castedArguments = e as ClickEventArgs;

            if(castedArguments == null)
            {
                throw new ArgumentException("Invalid event arguments are provided");
            }

            var commands = this.GetCommandList(castedArguments.CommandToPass);

            this.ExecuteCommandList(commands);
        }
    }
}
