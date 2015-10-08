namespace BalloonsPop.Core.Commands
{
    using System;

    using BalloonsPop.Common.Contracts;

    public class AddPlayerscoreCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.HighscoreTable.AddPlayer(new PlayerScore("bay ivan", context.Game.UserMovesCount, DateTime.Now));
        }
    }
}