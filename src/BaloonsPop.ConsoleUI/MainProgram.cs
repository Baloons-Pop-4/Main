namespace BaloonsPop.ConsoleUI
{
    using System;
    using BaloonsPop.Common.Contracts;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Engine.Commands;
    using System.Collections.Generic;

    using System.Linq;

    using BaloonsPop.Common;

    public class MainProgram
    {
        public static void Main()
        {
            var consoleUI = new ConsoleUI();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = new GameLogic(MatrixValidator.GetInstance, new RandomNumberGenerator());
            var gameModel = new Game(gameLogicProvider);
            
            var engine = new Engine(consoleUI, UserInputValidator.GetInstance, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }

    
}