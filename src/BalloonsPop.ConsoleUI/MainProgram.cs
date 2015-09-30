namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Bundling;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Validation;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.GameModels;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using Ninject;

    public class MainProgram
    {
        private static readonly ILogger logger = LogHelper.GetLogger();

        public static void Main()
        {
            logger.Info("Start initialization");
            var kernel = new StandardKernel();

            DependancyBinder.Instance
                .RegisterModules(new ModelsModule(kernel),
                                 new LogicModule(kernel),
                                 new ValidationModule(kernel),
                                 new CommandModule(kernel),
                                 new HighscoreModule(kernel),
                                 new ConsoleModule(kernel)
                                 )
                .LoadAll();            

            var bundle = new ConsoleBundle(kernel);
            var engine = new ConsoleEngine(bundle);

            logger.Info("Starting the game");
            engine.Run();
        }
    }

    
}