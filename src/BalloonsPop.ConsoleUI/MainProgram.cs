namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Core;
    using BalloonsPop.Core.Commands;

    using BalloonsPop.GameModels;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Highscore;
    using BalloonsPop.Bundling;

    using Ninject;

    public class MainProgram
    {
        public static void Main()
        {
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
            // var engine = new ConsoleEngine(consoleUI, userInputValidator, highscoreTable, highscoreSaver, commandFactory, gameModel, gameLogicProvider);
            var bundle = new ConsoleBundle(kernel);
            var engine = new ConsoleEngine(bundle);
            engine.Run();
        }
    }

    
}