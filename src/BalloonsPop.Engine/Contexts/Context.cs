namespace BalloonsPop.Engine.Contexts
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Context : IContext
    {
        public IGameModel Game { get; internal set; }

        public IGameLogicProvider LogicProvider { get; internal set; }

        public IPrinter Printer { get; internal set; }

        public IMemento<IGameModel> Memento{ get; internal set; }

        public string Message { get; set; }

        public int UserRow{ get; set; }

        public int UserCol{ get; set; }

        public Context()
        {
        }
    }
}