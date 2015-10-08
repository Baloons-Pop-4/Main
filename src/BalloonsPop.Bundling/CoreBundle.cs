namespace BalloonsPop.Bundling
{
    using BalloonsPop.Common.Contracts;

    using Ninject;

    /// <summary>
    /// Provides IoC container for EngineCore dependencies. Injected with ninject.
    /// </summary>
    public class CoreBundle : ICoreBundle
    {
        /// <summary>
        /// Public constructor which initializes the isntance through injection with the provided kernel.
        /// </summary>
        /// <param name="kernel"></param>
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

        [Inject]
        public IStateSaver<IGameModel> GameSaver { get; set; }
    }
}