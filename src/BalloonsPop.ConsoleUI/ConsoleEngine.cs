namespace BalloonsPop.ConsoleUI
{
    using System;

    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Core;

    public class ConsoleEngine : EngineCore, IConsoleEngine
    {
        private IInputReader reader;

        public ConsoleEngine(IConsoleBundle depenencyBundle)
            : base(depenencyBundle)
        {
            this.reader = depenencyBundle.Reader;
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