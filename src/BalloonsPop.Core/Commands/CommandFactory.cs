namespace BalloonsPop.Core.Commands
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implements a factory to create commands.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commandMap;
        // flyweight factory
        private readonly IDictionary<string, ICommand> commandCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory" /> class.
        /// </summary>
        public CommandFactory()
        {
            this.commandMap = new Dictionary<string, Func<ICommand>>();
            this.commandCache = new Dictionary<string, ICommand>();
            this.RegisterDefaults();
        }

        /// <summary>
        /// A method to create a command.
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns>New command</returns>
        public ICommand CreateCommand(string commandName)
        {
            if (!this.ContainsKey(commandName))
            {
                throw new KeyNotFoundException("No command with such key was registered");
            }

            if (!this.commandCache.ContainsKey(commandName))
            {
                this.commandCache.Add(commandName, this.commandMap[commandName]());
            }

            return this.commandCache[commandName];
        }

        /// <summary>
        /// A method to check if the command is already created.
        /// </summary>
        /// <param name="commandKey"></param>
        /// <returns>If the command is already registered</returns>
        public bool ContainsKey(string commandKey)
        {
            return this.commandMap.ContainsKey(commandKey);
        }

        /// <summary>
        /// A method to register a new command.
        /// </summary>
        /// <param name="commandKey"></param>
        /// <param name="commandProvidingMethod"></param>
        public void RegisterCommand(string commandKey, Func<ICommand> commandProvidingMethod)
        {
            if (!this.commandMap.ContainsKey(commandKey))
            {
                this.commandMap.Add(commandKey, commandProvidingMethod);
            }
        }

        /// <summary>
        /// A method to delete a command.
        /// </summary>
        /// <param name="commandKey"></param>
        public void UnregisterCommand(string commandKey)
        {
            this.commandMap.Remove(commandKey);
            this.commandCache.Remove(commandKey);
        }

        /// <summary>
        /// A method to register default commands.
        /// </summary>
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