namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Commands;

    public class MainProgram
    {
        public static void Main()
        {
            var consoleUI = new ConsoleUI();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = new GameLogic(MatrixValidator.GetInstance);
            var gameModel = new Game(gameLogicProvider.GenerateField());
            
            var engine = new ConsoleEngine(consoleUI, UserInputValidator.GetInstance, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }

    
}