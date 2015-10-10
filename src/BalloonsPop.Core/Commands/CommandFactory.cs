namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commandMap;
        private static readonly ILogger Logger = LogHelper.GetLogger();

        public CommandFactory()
        {
            this.commandMap = new Dictionary<string, Func<ICommand>>();
            this.RegisterDefaults();
        }

        public ICommand CreateCommand(string commandName)
        {
            try
            {
                this.commandMap.ContainsKey(commandName);
            }
            catch (Exception ex)
            {
                Logger.Error("Invalid type of command requested!", ex);
                throw;
            }

            return this.commandMap[commandName]();
        }

        public bool ContainsKey(string commandKey)
        {
            return this.commandMap.ContainsKey(commandKey);
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
            this.RegisterCommand("restart", () => new CompositeRestart());
            this.RegisterCommand("top", () => new PrintHighscoreCommand());
            this.RegisterCommand("message", () => new PrintMessageCommand());
            this.RegisterCommand("field", () => new PrintFieldCommand());
            this.RegisterCommand("exit", () => new ExitCommand());
            this.RegisterCommand("undo", () => new CompositeUndoCommand());
            this.RegisterCommand("pop", () => new CompositePopCommand());
            this.RegisterCommand("save", () => new SaveCommand());
            this.RegisterCommand("gameover", () => new GameOverHandlingCommand());
        }
    }
}