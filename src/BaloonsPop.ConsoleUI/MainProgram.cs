namespace BaloonsPop.ConsoleUI
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Engine.Commands;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = Engine.Instance;

            var consoleUI = new ConsoleUI();
            var commandFactory = new CommandFactory();
            var gameLogicProvider = new GameLogic(MatrixValidator.GetInstance);
            var gameModel = new Game(gameLogicProvider);

            engine.Initialize(consoleUI, UserInputValidator.GetInstance, commandFactory, gameModel, gameLogicProvider);
            engine.Run();
        }
    }
}