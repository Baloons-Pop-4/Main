namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Bundling;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Core.Memento;
    using BalloonsPop.GameModels;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Validation;
    using Ninject;

    public class MainProgram
    {
        private static readonly ILogger Logger = LogHelper.GetLogger();

        public static void Main()
        {
            Logger.Info("Start initialization");
            var kernel = new StandardKernel();

            DependancyBinder.Instance
                .RegisterModules(
                    new ModelsModule(kernel),
                    new LogicModule(kernel),
                    new ValidationModule(kernel),
                    new CommandModule(kernel),
                    new HighscoreModule(kernel),
                    new ConsoleModule(kernel))
                .LoadAll();

            kernel.Bind<IStateSaver<IGameModel>>().To<Saver<IGameModel>>();

            var bundle = new ConsoleBundle(kernel);
            var engine = new ConsoleEngine(bundle);

            Logger.Info("Starting the game");
            engine.Run();
        }
    }
}