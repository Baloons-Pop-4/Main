namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;
    using System;

    public class GameOverHandlingCommand : ICommand
    {
        public void Execute(IContext context)
        {
            if (context.LogicProvider.GameIsOver(context.Game.Field))
            {
                context.Printer.PrintMessage("Gratz, completed in " + context.Game.UserMovesCount + " moves.");
                if (context.HighscoreTable.CanAddPlayer(context.Game.UserMovesCount))
                {
                    // TODO: Abstract to work with all types of UIs, not just the console?
                    context.Printer.PrintMessage("Type in your name: ");
                    string username = "bay ivan";

                    context.HighscoreTable.AddPlayer(new PlayerScore(username, context.Game.UserMovesCount, DateTime.Now));
                    context.Printer.PrintHighscore(context.HighscoreTable);
                }

                new RestartCommand().Execute(context);
            }
        }
    }
}
