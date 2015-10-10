namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class GameOverHandlingCommand : CompositeCommand
    {
        public GameOverHandlingCommand()
        {
            this.SubCommands = new List<ICommand>();
        }

        public override void Execute(IContext context)
        {
            if (context.LogicProvider.GameIsOver(context.Game.Field))
            {
                context.Message = "Gratz, completed in " + context.Game.UserMovesCount + " moves.";
                this.SubCommands.Add(new PrintMessageCommand());
                if (context.HighscoreTable.CanAddPlayer(context.Game.UserMovesCount))
                {
                    this.SubCommands.Add(new PrintHighscoreCommand());
                    this.SubCommands.Add(new AddPlayerscoreCommand());
                }

                this.SubCommands.Add(new CompositeRestart());
            }

            base.Execute(context);
        }
    }
}
