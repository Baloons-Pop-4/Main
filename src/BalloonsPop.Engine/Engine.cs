namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;
    using BalloonsPop.Engine.Memento;
    using BalloonsPop.Engine.Contexts;

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

        private ICommandFactory commandFactory;

        //private IGameModel game;

        //private IGameLogicProvider gameLogicProvider;

        //private IMemento<IGameModel> memento = new Memento<IGameModel>();

        private IContext context;

        public Engine(IUserInterface ui, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
        {
            this.userInterface = ui;
            this.validator = validator;
            this.commandFactory = commandFactory;
            //this.game = gameModel;
            //this.gameLogicProvider = gameLogicProvider;
            this.highScoreChart = new string[2, 5];

            this.context = new Context()
            {
                Game = gameModel,
                LogicProvider = gameLogicProvider,
                Memento = new Memento<IGameModel>(),
                Printer = this.userInterface
            };
        }

        public void Run()
        {
            this.userInterface.PrintField(this.context.Game.Field);
            var command = string.Empty;

            while (true)
            {
                // this.commandFactory.PrintMessageCommand(this.userInterface, MOVE_PROMPT).Execute();
                this.context.Message = MOVE_PROMPT;
                this.commandFactory.CreateCommand("message").Execute(this.context);
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
                    
                    commandList.Add(this.commandFactory.CreateCommand("save"));
                    commandList.Add(this.commandFactory.CreateCommand("restart"));
                    commandList.Add(this.commandFactory.CreateCommand("field"));
                    break;

                case TOP:
                    commandList.Add(this.commandFactory.CreateCommand("highscore"));
                    break;

                case EXIT:
                    this.context.Message = ON_EXIT_MESSAGE;
                    commandList.Add(this.commandFactory.CreateCommand("message"));
                    commandList.Add(this.commandFactory.CreateCommand("exit"));    

                    break;

                case "UNDO":

                    commandList.Add(this.commandFactory.CreateCommand("undo"));
                    commandList.Add(this.commandFactory.CreateCommand("field"));
                    break;

                default:
                    commandList.Add(this.commandFactory.CreateCommand("save"));

                    if (!this.validator.IsValidUserMove(userCommand))
                    {
                        this.context.Message = WRONG_INPUT;
                        commandList.Add(this.commandFactory.CreateCommand("message"));
                        break;
                    }

                    var userRow = int.Parse(userCommand[0].ToString());
                    var userColumn = int.Parse(userCommand[2].ToString());

                    if (this.context.Game.Field[userRow, userColumn] == 0)
                    {
                        this.context.Message = CANNOT_POP_MISSING_BALLOON;
                        commandList.Add(this.commandFactory.CreateCommand("message"));
                    }
                    else
                    {
                        this.context.UserRow = userRow;
                        this.context.UserCol = userColumn;
                        commandList.Add(this.commandFactory.CreateCommand("pop"));                    
                    }

                    if (this.context.LogicProvider.GameIsOver(this.context.Game.Field))
                    {
                        this.context.Message = "Gratz, completed in " + this.context.Game.UserMovesCount + " moves";
                        commandList.Add(this.commandFactory.CreateCommand("message"));
                        commandList.Add(this.commandFactory.CreateCommand("restart"));
                    } else
                    {
                        commandList.Add(this.commandFactory.CreateCommand("field"));
                    }
                    
                    break;
            }

            return commandList;
        }

        protected virtual void ExecuteCommandList(IList<ICommand> commandList)
        {
            foreach (var command in commandList)
            {
                command.Execute(this.context);
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