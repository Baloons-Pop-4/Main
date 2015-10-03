namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commandMap;

        public CommandFactory()
        {
            this.commandMap = new Dictionary<string, Func<ICommand>>();
            this.RegisterDefaults();
        }

        public ICommand CreateCommand(string commandName)
        {
            if (!this.commandMap.ContainsKey(commandName))
            {
                throw new ArgumentException("Invalid type of command requested!");
            }

            return this.commandMap[commandName]();
        }

        public void RegisterCommand(string commandKey, Func<ICommand> commandProvidingMethod)
        {
            if (!this.commandMap.ContainsKey(commandKey))
            {
                this.commandMap.Add(commandKey, commandProvidingMethod);
            }
        }

        public void UnregisterCommand(string commandKey)
        {
            this.commandMap.Remove(commandKey);
        }

        private void RegisterDefaults()
        {
            this.RegisterCommand("restart", () => new RestartCommand());
            this.RegisterCommand("top", () => new PrintHighscoreCommand());
            this.RegisterCommand("message", () => new PrintMessageCommand());
            this.RegisterCommand("field", () => new PrintFieldCommand());
            this.RegisterCommand("exit", () => new ExitCommand());
            this.RegisterCommand("undo", () => new UndoCommand());
            this.RegisterCommand("pop", () => new PopBalloonCommand());
            this.RegisterCommand("save", () => new SaveCommand());
        }
    }
}