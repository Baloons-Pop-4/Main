namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Core;
    using BalloonsPop.Core.Commands;

    public class MainProgram
    {
        public static void Main()
        {
            var consoleUI = new ConsoleUI();
            var highscoreTable = new HighscoreTable();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = new LogicProvider(MatrixValidator.GetInstance);
            var gameModel = new GameModel(gameLogicProvider.GenerateField());
            
            var engine = new ConsoleEngine(consoleUI, UserInputValidator.GetInstance, highscoreTable, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }

    
}