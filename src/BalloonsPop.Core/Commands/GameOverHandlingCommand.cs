namespace BalloonsPop.Core.Commands
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements command to handle game over
    /// </summary>
    public class GameOverHandlingCommand : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverHandlingCommand" /> class.
        /// </summary>
        public GameOverHandlingCommand()
        {
            this.SubCommands = new List<ICommand>();
        }

        /// <summary>
        /// Executes GameOverHandlingCommand
        /// </summary>
        /// <param name="context"></param>
        public override void Execute(IContext context)
        {
            if (context.LogicProvider.GameIsOver(context.Game.Field))
            {
                context.Message = "Gratz, completed in " + context.Game.UserMovesCount + " moves.";
                this.SubCommands.Add(new PrintMessageCommand());
                if (context.HighscoreTable.CanAddPlayer(context.Game.UserMovesCount))
                {
                    this.SubCommands.Add(new AddPlayerscoreCommand());
                    this.SubCommands.Add(new PrintHighscoreCommand());
                }

                this.SubCommands.Add(new PlaySoundCommand("win"));
                this.SubCommands.Add(new CompositeRestart());

                base.Execute(context);

                this.SubCommands.Clear();
            }
        }
    }
}
