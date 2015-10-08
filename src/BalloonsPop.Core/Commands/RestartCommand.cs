﻿namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    public class RestartCommand : ICommand
    {
        public void Execute(IContext context)
        {
            context.LogicProvider.RandomizeBalloonField(context.Game.Field);
            context.Game.ResetUserMoves();
        }
    }
}