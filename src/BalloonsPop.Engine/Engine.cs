namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine.Commands;
    using System.Collections.Generic;
    using BalloonsPop.Engine.Memento;

    public class Engine : IEngine
    {
        #region Constants
        private const string EXIT = "EXIT";
        private const string TOP = "TOP";
        private const string RESTART = "RESTART";
        private const string WRONG_INPUT = "Wrong input! Try Again!";
        private const string CANNOT_POP_MISSING_BALLOON = "Cannot pop missing ballon!";
        private const string WIN_MESSAGE_TEMPLATE = "Gratz ! You completed it in {0} moves.";
        private const string NOT_IN_TOP_FIVE = "I am sorry you are not skillful enough for TopFive chart!";
        private const string MOVE_PROMPT = "Enter a row and column: ";
        private const string ON_EXIT_MESSAGE = "Good Bye!";
        #endregion

        private string[,] highScoreChart;

        private IUserInterface userInterface;

        private IUserInputValidator validator;

        private ICommandFactory create;

        private IGameModel game;

        private IGameLogicProvider gameLogicProvider;

        private IMemento<IGameModel> memento = new Memento<IGameModel>();

        public Engine(IUserInterface ui, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
        {
            this.userInterface = ui;
            this.validator = validator;
            this.create = commandFactory;
            this.game = gameModel;
            this.gameLogicProvider = gameLogicProvider;
            this.highScoreChart = new string[2, 5];
        }

        public void Run()
        {
            this.userInterface.PrintField(game.Field);
            var command = string.Empty;

            while (true)
            {
                this.create.PrintMessageCommand(this.userInterface, MOVE_PROMPT).Execute();

                command = this.GetTrimmedUppercaseInput();

                var commandList = this.GetCommandList(command);

                this.ExecuteCommandList(commandList);
            }
        }
        
        protected virtual IList<ICommand> GetCommandList(string userCommand)
        {
            var commandList = new List<ICommand>();

            switch (userCommand)
            {
                case RESTART:
                    commandList.Add(new SaveCommand(this.game, this.memento));
                    commandList.Add(this.create.RestartCommand(this.game, this.gameLogicProvider));
                    commandList.Add(this.create.PrintFieldCommand(this.userInterface, game));
                    break;

                case TOP:

                    commandList.Add(this.create.PrintHighscoreCommand(this.userInterface, this.highScoreChart));

                    break;

                case EXIT:

                    commandList.Add(this.create.PrintMessageCommand(this.userInterface, ON_EXIT_MESSAGE));
                    commandList.Add(this.create.ExitCommand());

                    break;

                case "UNDO":

                    commandList.Add(new UndoCommand(this.game, this.memento));
                    commandList.Add(new PrintFieldCommand(this.userInterface, this.game));
                    break;

                default:

                    commandList.Add(new SaveCommand(this.game, this.memento));

                    if (!this.validator.IsValidUserMove(userCommand))
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, WRONG_INPUT));

                        break;
                    }

                    var userRow = int.Parse(userCommand[0].ToString());
                    var userColumn = int.Parse(userCommand[2].ToString());

                    if (game.Field[userRow, userColumn] == 0)
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, CANNOT_POP_MISSING_BALLOON));
                    }
                    else
                    {
                        commandList.Add(this.create.PopBalloonCommand(this.game, this.gameLogicProvider, userRow, userColumn));
                    }

                    if (gameLogicProvider.GameIsOver(game.Field))
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, string.Format(WIN_MESSAGE_TEMPLATE, game.UserMovesCount)));

                        HighScoreUtility.SignIfSkilled(this.highScoreChart, this.game.UserMovesCount);

                        commandList.Add(this.create.PrintHighscoreCommand(this.userInterface, this.highScoreChart));
                    }

                    commandList.Add(this.create.PrintFieldCommand(this.userInterface, this.game));
                    
                    break;
            }

            return commandList;
        }

        protected virtual void ExecuteCommandList(IList<ICommand> commandList)
        {
            foreach (var command in commandList)
            {
                command.Execute();
            }
        }

        private string GetTrimmedUppercaseInput()
        {
            var inputAsString = this.userInterface.ReadUserInput();
            var trimmedUppercaseInput = inputAsString.Trim().ToUpper();

            return trimmedUppercaseInput;
        }
    }
}