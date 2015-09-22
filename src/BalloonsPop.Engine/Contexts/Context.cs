namespace BalloonsPop.Engine.Contexts
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Context : IContext
    {
        public IGameModel Game { get; set; }

        public IGameLogicProvider LogicProvider { get; set; }

        public IPrinter Printer { get; set; }

        public IMemento<IGameModel> Memento{ get; set; }

        public IHighscoreTable HighscoreTable { get; internal set; }

        public string Message { get; set; }

        public int UserRow{ get; set; }

        public int UserCol{ get; set; }

        public Context()
        {
        }
    }
}