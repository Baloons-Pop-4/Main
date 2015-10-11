namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Bundling;
    using BalloonsPop.Commands;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Core.Contexts;
    using BalloonsPop.GameModels;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Saver;
    using BalloonsPop.Validation;
    using Ninject;

    public class MainProgram
    {
        private static readonly ILogger Logger = LogHelper.GetLogger();

        public static void Main()
        {
            Logger.Info("Start initialization.");
            var kernel = new StandardKernel();
            // TODO: create logger module
            kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());
            DependancyBinder.Instance
                .RegisterModules(
                    new ModelsModule(kernel),
                    new LogicModule(kernel),
                    new ValidationModule(kernel),
                    new CommandModule(kernel),
                    new HighscoreModule(kernel),
                    new SaverModule(kernel),
                    new ConsoleModule(kernel))
                .LoadAll();

            var ctx = new Context(kernel);
            var bundle = new ConsoleBundle(kernel);

            // TODO: extract in a module
            bundle.CommandFactory.RegisterCommand("exit", () => new ExitCommand());

            var engine = new ConsoleEngine(ctx, bundle);

            Logger.Info("Starting the game.");
            engine.Run();
        }
    }
}