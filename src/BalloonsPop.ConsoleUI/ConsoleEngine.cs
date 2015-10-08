namespace BalloonsPop.ConsoleUI
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Core;

    public class ConsoleEngine : EngineCore, IConsoleEngine
    {
        private IInputReader reader;

        public ConsoleEngine(IConsoleBundle depenencyBundle)
            : base(depenencyBundle)
        {
            this.reader = depenencyBundle.Reader;
            //this.Context.LogicProvider.RandomizeBalloonField(this.Context.Game.Field);
        }

        public ConsoleEngine(
            IConsoleUserInterface consoleUI,
            IUserInputValidator validator,
            IHighscoreTable highscoreTable,
            IHighscoreHandlingStrategy highscoreHandlingStrategy,
            ICommandFactory commandFactory,
            IGameModel gameModel,
            IGameLogicProvider gameLogicProvider)
            : base(consoleUI, validator, highscoreTable, highscoreHandlingStrategy, commandFactory, gameModel, gameLogicProvider)
        {
            this.reader = consoleUI;
            //this.Context.Game.Field = this.Context.LogicProvider.GenerateField();
        }

        public void Run()
        {
            this.Context.Printer.PrintField(this.Context.Game.Field);
            var command = string.Empty;

            while (true)
            {
                this.Context.Message = EngineCore.MovePrompt;
                this.CommandFactory.CreateCommand("message").Execute(this.Context);
                command = this.GetTrimmedUppercaseInput();

                var commandList = this.GetCommandList(command);
                this.ExecuteCommandList(commandList);
            }
        }

        private string GetTrimmedUppercaseInput()
        {
            var inputAsString = this.reader.ReadUserInput();
            var trimmedUppercaseInput = inputAsString.Trim().ToUpper();

            return trimmedUppercaseInput;
        }
    }
}