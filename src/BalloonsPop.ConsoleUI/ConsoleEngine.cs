namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Core;

    public class ConsoleEngine : EngineCore, IConsoleEngine
    {
        private const string MovePrompt = "Enter a row and column: ";
        private const string PrintMessageCommandKey = "message";

        private IInputReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleEngine" /> class.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="depBundle"></param>
        public ConsoleEngine(IContext ctx, IConsoleBundle depBundle)
            : base(ctx, depBundle.UserInputValidator, depBundle.CommandFactory, depBundle.Logger)
        {
            this.reader = depBundle.Reader;
        }

        public void Run()
        {
            this.Context.Printer.PrintField(this.Context.Game.Field);
            var command = string.Empty;

            while (true)
            {
                this.Context.Message = MovePrompt;
                this.CommandFactory.CreateCommand(PrintMessageCommandKey).Execute(this.Context);
                command = this.GetTrimmedUppercaseInput();

                var parsedCommand = this.GetCommandList(command);
                parsedCommand.Execute(this.Context);
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