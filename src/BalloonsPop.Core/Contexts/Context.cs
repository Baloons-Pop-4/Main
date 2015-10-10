namespace BalloonsPop.Core.Contexts
{
    using BalloonsPop.Common.Contracts;

    using Ninject;

    /// <summary>
    /// Provides access to the components which defined that context of execution for the application.
    /// </summary>
    public class Context : IContext
    {
        private const string DefaultPlayerName = "Player";
        private const string StartUpMessage = "Welcome to balloons pop!";
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// Allows creating and initializing the context manually.
        /// </summary>
        public Context()
        {
            this.PlayerName = DefaultPlayerName;
            this.Message = StartUpMessage;
        }

        /// <summary>
        /// Uses a Ninject kernel to inject the current instance.
        /// </summary>
        /// <param name="appKernel"></param>
        public Context(IKernel appKernel)
            :this()
        {
            appKernel.Inject(this);
        }

        /// <summary>
        /// Provides access to the game model.
        /// </summary>
        [Inject]
        public IGameModel Game { get; set; }

        /// <summary>
        /// Provides access to the logic provider
        /// </summary>
        [Inject]
        public IGameLogicProvider LogicProvider { get; set; }

        /// <summary>
        /// Provides access to the printer.
        /// </summary>
        [Inject]
        public IPrinter Printer { get; set; }

        /// <summary>
        /// Provides access to the state saver for the game object.
        /// </summary>
        [Inject]
        public IStateSaver<IGameModel> Memento { get; set; }

        /// <summary>
        /// Provides access to the applications high score table.
        /// </summary>
        [Inject]
        public IHighscoreTable HighscoreTable { get; set; }

        /// <summary>
        /// Provides access to the chosen high score handling strategy.
        /// </summary>
        [Inject]
        public IHighscoreHandlingStrategy HighscoreHandling { get; set; }

        /// <summary>
        /// Provides the current "message" that describes the current state of the engine.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Provides the nickname of the person currently playing the game.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Provides default(INT32) or, in case of valid pop input, the parsed row of the balloon.
        /// </summary>
        public int UserRow { get; set; }

        /// <summary>
        /// Provides default(INT32) or, in case of valid pop input, the parsed column of the balloon.
        /// </summary>
        public int UserCol { get; set; }
    }
}