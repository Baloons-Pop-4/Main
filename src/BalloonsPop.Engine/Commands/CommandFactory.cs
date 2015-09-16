namespace BalloonsPop.Engine.Commands
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName)
        {
            switch (commandName)
            {
                case "restart":
                    return new RestartCommand();
                case "top":
                    return new PrintHighscoreCommand();
                case "message":
                    return new PrintMessageCommand();
                case "field":
                    return new PrintFieldCommand();
                case "exit":
                    return new ExitCommand();
                case "save":
                    return new SaveCommand();
                case "undo":
                    return new UndoCommand();
                case "pop":
                    return new PopBalloonCommand();
                default:
                    throw new ArgumentException("Invalid type of command requested!");
            }
        }

        public CommandFactory()
        {
        }

    }
}