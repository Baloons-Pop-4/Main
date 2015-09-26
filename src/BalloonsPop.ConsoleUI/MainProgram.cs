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

    using Ninject;

    public class MainProgram
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            var models = new ModelsModule(kernel);
            models.Load();
            var logic = new LogicModule(kernel);
            logic.Load();
            var validators = new ValidationModule(kernel);
            validators.Load();
            var highscores = new HighscoreModule(kernel);
            highscores.Load();
            
            var consoleUI = new ConsoleUI();
            var highscoreTable = kernel.Get<IHighscoreTable>();
            var highscoreSaver = kernel.Get<IHighscoreSaver>();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = kernel.Get<IGameLogicProvider>();// new LogicProvider(new MatrixValidator());
            var gameModel = kernel.Get<IGameModel>();// new GameModel(gameLogicProvider.GenerateField());
            var userInputValidator = kernel.Get<IUserInputValidator>();
            
            var engine = new ConsoleEngine(consoleUI, userInputValidator, highscoreTable, highscoreSaver, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }

    
}