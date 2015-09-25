namespace BalloonsPop.ConsoleUI
{
    using System;

    using BalloonsPop.Core;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;

    public class ConsoleEngine : EngineCore, IConsoleEngine
    {
        private IInputReader reader;

        public ConsoleEngine(IConsoleUserInterface consoleUI, IUserInputValidator validator, IHighscoreTable highscoreTable, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
            : base(consoleUI, validator, highscoreTable, commandFactory, gameModel, gameLogicProvider)
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
                this.context.Message = MOVE_PROMPT;
                this.commandFactory.CreateCommand("message").Execute(this.context);
                command = this.GetTrimmedUppercaseInput();

                var commandList = this.GetCommandList(command);
                // Console.Clear();
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