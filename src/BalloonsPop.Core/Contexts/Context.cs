namespace BalloonsPop.Core.Contexts
{
    using BalloonsPop.Common.Contracts;

    using Ninject;

    public class Context : IContext
    {
        public Context()
        {
        }

        public Context(IKernel appKernel)
        {
            appKernel.Inject(this);
        }

        [Inject]
        public IGameModel Game { get; set; }

        [Inject]
        public IGameLogicProvider LogicProvider { get; set; }

        [Inject]
        public IPrinter Printer { get; set; }

        [Inject]
        public IStateSaver<IGameModel> Memento { get; set; }

        [Inject]
        public IHighscoreTable HighscoreTable { get; set; }

        [Inject]
        public IHighscoreHandlingStrategy HighscoreHandling { get; set; }

        public string Message { get; set; }

        public int UserRow { get; set; }

        public int UserCol { get; set; }
    }
}