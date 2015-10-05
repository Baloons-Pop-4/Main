namespace BalloonsPop.Bundling
{
    using BalloonsPop.Common.Contracts;
    using Ninject;

    public class CoreBundle : ICoreBundle
    {
        public CoreBundle(IKernel kernel)
        {
            kernel.Inject(this);
        }

        [Inject]
        public IPrinter Printer { get; set; }

        [Inject]
        public IUserInputValidator UserInputValidator { get; set; }

        [Inject]
        public IHighscoreTable HighScoreTable { get; set; }

        [Inject]
        public IHighscoreHandlingStrategy HighscoreHandlingStrategy { get; set; }

        [Inject]
        public ICommandFactory CommandFactory { get; set; }

        [Inject]
        public IGameModel GameModel { get; set; }

        [Inject]
        public IGameLogicProvider LogicProvider { get; set; }
    }
}