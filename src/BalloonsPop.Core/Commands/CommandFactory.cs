namespace BalloonsPop.Core.Commands
{
    using System;
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;

    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> commandMap;

        public ICommand CreateCommand(string commandName)
        {
            //switch (commandName)
            //{
            //    case "restart":
            //        return new RestartCommand();
            //    case "top":
            //        return new PrintHighscoreCommand();
            //    case "message":
            //        return new PrintMessageCommand();
            //    case "field":
            //        return new PrintFieldCommand();
            //    case "exit":
            //        return new ExitCommand();
            //    case "save":
            //        return new SaveCommand();
            //    case "undo":
            //        return new UndoCommand();
            //    case "pop":
            //        return new PopBalloonCommand();
            //    default:
            //        throw new ArgumentException("Invalid type of command requested!");
            //}

            if (!this.commandMap.ContainsKey(commandName))
            {
                throw new ArgumentException("Invalid type of command requested!");
            }

            return this.commandMap[commandName]();
        }

        public CommandFactory()
        {
            this.commandMap = new Dictionary<string, Func<ICommand>>();
            this.RegisterDefaults();
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