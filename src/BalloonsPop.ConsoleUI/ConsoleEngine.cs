namespace BalloonsPop.ConsoleUI
{
    using System;
using BalloonsPop.Common.Contracts;
using BalloonsPop.ConsoleUI.Contracts;
using BalloonsPop.Core;

    public class ConsoleEngine : EngineCore, IConsoleEngine
    {
        private IInputReader reader;

        public ConsoleEngine(IContext ctx, IConsoleBundle depBundle)
            :base(ctx, depBundle.UserInputValidator, depBundle.CommandFactory)
        {
            this.reader = depBundle.Reader;
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