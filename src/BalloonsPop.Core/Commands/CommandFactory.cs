namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commandMap;
        // flyweight factory
        private readonly IDictionary<string, ICommand> commandCache;

        public CommandFactory()
        {
            this.commandMap = new Dictionary<string, Func<ICommand>>();
            this.commandCache = new Dictionary<string, ICommand>();
            this.RegisterDefaults();
        }

        public ICommand CreateCommand(string commandName)
        {
            if(!this.ContainsKey(commandName))
            {
                throw new KeyNotFoundException("No command with such key was registered");
            }
            
            if(!this.commandCache.ContainsKey(commandName))
            {
                this.commandCache.Add(commandName, this.commandMap[commandName]());
            }

            return this.commandCache[commandName];
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
            this.commandCache.Remove(commandKey);
        }

        private void RegisterDefaults()
        {
            // TODO: find a pretty way to register defaults
            this.RegisterCommand("restart", () => new CompositeRestart());
            this.RegisterCommand("top", () => new PrintHighscoreCommand());
            this.RegisterCommand("message", () => new PrintMessageCommand());
            this.RegisterCommand("field", () => new PrintFieldCommand());
            this.RegisterCommand("undo", () => new CompositeUndoCommand());
            this.RegisterCommand("pop", () => new CompositePopCommand());
            this.RegisterCommand("save", () => new SaveCommand());
            this.RegisterCommand("gameover", () => new GameOverHandlingCommand());
        }
    }
}