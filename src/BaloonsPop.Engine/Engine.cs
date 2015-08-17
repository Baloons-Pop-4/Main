namespace BaloonsPop.Engine
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine.Commands;
using System.Collections.Generic;

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

        private static Engine instance = new Engine();

        private string[,] highScoreChart;

        private IUserInterface userInterface;

        private IUserInputValidator validator;

        private ICommandFactory create;

        private IGameModel game;

        private IGameLogicProvider gameLogicProvider;

        private Engine()
        {
            this.highScoreChart = new string[2, 5];
        }

        public static IEngine Instance
        {
            get
            {
                return Engine.instance;
            }
        }

        public void Initialize(IUserInterface ui, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
        {
            this.userInterface = ui;
            this.validator = validator;
            this.create = commandFactory;
            this.game = gameModel;
            this.gameLogicProvider = gameLogicProvider;
        }

        public void Run()
        {
            this.userInterface.PrintField(game.Field);
            var command = string.Empty;

            while (true)
            {
                this.userInterface.PrintMessage(MOVE_PROMPT);
                command = this.GetTrimmedUppercaseInput();

                //switch (command)
                //{
                //    case RESTART:

                //        var restartCommand = this.create.RestartCommand(this.game);
                //        restartCommand.Execute();

                //        var printFieldCommand = this.create.PrintFieldCommand(this.userInterface, game.Field);
                //        printFieldCommand.Execute();

                //        break;

                //    case TOP:

                //        var printHighscoreCommand = this.create.PrintHighscoreCommand(this.userInterface, this.highScoreChart);
                        
                //        break;

                //    case EXIT:

                //        var printMessageCommand = this.create.PrintMessageCommand(this.userInterface, ON_EXIT_MESSAGE);
                //        printMessageCommand.Execute();

                //        var exitCommand = this.create.ExitCommand();
                //        exitCommand.Execute();

                //        break;

                //    default:

                //        if (!this.validator.IsValidUserMove(command))
                //        {
                //            this.userInterface.PrintMessage(WRONG_INPUT);

                //            break;
                //        }

                //        var userRow = int.Parse(command[0].ToString());
                //        var userColumn = int.Parse(command[2].ToString());

                //        // this condition should be a GameLogic method
                //        if (game.Field[userRow, userColumn] == 0)
                //        {
                //            this.userInterface.PrintMessage(CANNOT_POP_MISSING_BALLOON);
                //            continue;
                //        }
                //        else
                //        {
                //            // GameLogic.change(game.Field, userRow, userColumn);
                //            gameLogicProvider.PopBaloons(game.Field, userRow, userColumn);
                //            gameLogicProvider.LetBaloonsFall(game.Field);
                //        }

                //        game.IncrementMoves();

                //        // win condition
                //        // GameLogic should have an IsGameWon method
                //        if (gameLogicProvider.GameIsOver(game.Field))
                //        {
                //            this.EndGame(this.highScoreChart, game.UserMovesCount);
                            
                //            // new game
                //            game.Reset();
                //        }

                //        this.userInterface.PrintField(game.Field);
                //        break;
                //}

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

                    commandList.Add(this.create.RestartCommand(this.game));
                    commandList.Add(this.create.PrintFieldCommand(this.userInterface, game.Field));

                    break;

                case TOP:

                    commandList.Add(this.create.PrintHighscoreCommand(this.userInterface, this.highScoreChart));

                    break;

                case EXIT:

                    commandList.Add(this.create.PrintMessageCommand(this.userInterface, ON_EXIT_MESSAGE));
                    commandList.Add(this.create.ExitCommand());

                    break;

                default:

                    if (!this.validator.IsValidUserMove(userCommand))
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, WRONG_INPUT));

                        break;
                    }

                    var userRow = int.Parse(userCommand[0].ToString());
                    var userColumn = int.Parse(userCommand[2].ToString());

                    // this condition should be a GameLogic method
                    if (game.Field[userRow, userColumn] == 0)
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, CANNOT_POP_MISSING_BALLOON));
                    }
                    else
                    {
                        // GameLogic.change(game.Field, userRow, userColumn);
                        gameLogicProvider.PopBaloons(game.Field, userRow, userColumn);
                        gameLogicProvider.LetBaloonsFall(game.Field);
                        game.IncrementMoves();

                        commandList.Add(this.create.PopBaloonCommand(this.game, this.gameLogicProvider, userRow, userColumn));
                    }

                    // win condition
                    // GameLogic should have an IsGameWon method
                    if (gameLogicProvider.GameIsOver(game.Field))
                    {
                        commandList.Add(this.create.PrintMessageCommand(this.userInterface, string.Format(WIN_MESSAGE_TEMPLATE, game.UserMovesCount)));

                        HighScoreUtility.SignIfSkilled(this.highScoreChart, this.game.UserMovesCount);

                        commandList.Add(this.create.PrintHighscoreCommand(this.userInterface, this.highScoreChart));
                    }

                    commandList.Add(this.create.PrintFieldCommand(this.userInterface, this.game.Field));

                    break;
            }

            return commandList;
        }

        private void ExecuteCommandList(IList<ICommand> commandList)
        {
            foreach (var command in commandList)
            {
                command.Execute();
            }
        }

        private void EndGame(string[,] topFive, int userMoves)
        {
            this.userInterface.PrintMessage(string.Format(WIN_MESSAGE_TEMPLATE, userMoves));

            if (HighScoreUtility.SignIfSkilled(topFive, userMoves))
            {
                HighScoreUtility.SortAndPrintChartFive(topFive);
            }
            else
            {
                this.userInterface.PrintMessage(NOT_IN_TOP_FIVE);
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