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
            this.context.Game.Field = this.context.LogicProvider.GenerateField();
        }

        public ConsoleEngine(IConsoleUserInterface consoleUI, IUserInputValidator validator, IHighscoreTable highscoreTable, IHighscoreSaver highscoreSaver, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
            : base(consoleUI, validator, highscoreTable, highscoreSaver, commandFactory, gameModel, gameLogicProvider)
        {
            this.reader = consoleUI as IInputReader;
            this.context.Game.Field = this.context.LogicProvider.GenerateField();
        }

        public void Run()
        {
            this.context.Printer.PrintField(this.context.Game.Field);
            var command = string.Empty;

            while (true)
            {
                this.context.Message = EngineCore.MovePrompt;
                this.commandFactory.CreateCommand("message").Execute(this.context);
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