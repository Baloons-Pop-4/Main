namespace BaloonsPop.Engine
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine.Commands;

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

        private IUserInterface userInterface;

        private IUserInputValidator validator;

        private ICommandFactory create;

        private IGameModel game;

        private IGameLogicProvider gameLogicProvider;

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
            // this.Initialize(new ConsoleUI(), ValidationProvider.InputValidator);
            string[,] topFive = new string[5, 2];

            this.userInterface.PrintField(game.Field);
            var command = string.Empty;

            while (true)
            {
                this.userInterface.PrintMessage(MOVE_PROMPT);
                command = this.GetTrimmedUppercaseInput();

                switch (command)
                {
                    case RESTART:

                        var restartCommand = this.create.RestartCommand(this.game);
                        restartCommand.Execute();

                        var printFieldCommand = this.create.PrintFieldCommand(this.userInterface, game.Field);
                        printFieldCommand.Execute();

                        break;

                    case TOP:

                        HighScoreUtility.SortAndPrintChartFive(topFive);
                        
                        break;

                    case EXIT:

                        var printMessageCommand = this.create.PrintMessageCommand(this.userInterface, ON_EXIT_MESSAGE);
                        printMessageCommand.Execute();

                        var exitCommand = this.create.ExitCommand();
                        exitCommand.Execute();

                        break;

                    default:

                        if (!this.validator.IsValidUserMove(command))
                        {
                            this.userInterface.PrintMessage(WRONG_INPUT);

                            break;
                        }

                        var userRow = int.Parse(command[0].ToString());
                        var userColumn = int.Parse(command[2].ToString());

                        // this condition should be a GameLogic method
                        if (game.Field[userRow, userColumn] == 0)
                        {
                            this.userInterface.PrintMessage(CANNOT_POP_MISSING_BALLOON);
                            continue;
                        }
                        else
                        {
                            // GameLogic.change(game.Field, userRow, userColumn);
                            gameLogicProvider.PopBaloons(game.Field, userRow, userColumn);
                            gameLogicProvider.LetBaloonsFall(game.Field);
                        }

                        game.IncrementMoves();

                        // win condition
                        // GameLogic should have an IsGameWon method
                        if (gameLogicProvider.GameIsOver(game.Field))
                        {
                            this.EndGame(topFive, game.UserMovesCount);
                            
                            // new game
                            game.Reset();
                        }

                        this.userInterface.PrintField(game.Field);
                        break;
                }
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