namespace Engine
{
    using System;

    using GameLogic;
    using Contracts;

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

        // Singleton design pattern

        private static Engine instance = new Engine();

        private IBaloonsUserInterface UI;

        private IUserInputValidator validator;

        private Engine()
        {

        }

        public static IEngine Instance
        {
            get
            {
                return Engine.instance;
            }
        }

        public void Initialize(IBaloonsUserInterface UI, IUserInputValidator validator)
        {
            this.UI = UI;
            this.validator = validator;
        }

        public void Run()
        {
            // this.Initialize(new ConsoleUI(), ValidationProvider.InputValidator);

            string[,] topFive = new string[5, 2];
            var gameLogicProvider = new GameLogic(Validations.ValidationProvider.Validator);
            var game = new Game(gameLogicProvider);

            this.UI.PrintField(game.Field);
            var command = string.Empty;

            while (true)
            {
                this.UI.PrintMessage(MOVE_PROMPT);
                command = this.GetTrimmedUppercaseInput();

                switch (command)
                {
                    case RESTART:
                        game.Reset();
                        this.UI.PrintField(game.Field);
                        break;

                    case TOP:
                        HighScoreUtility.sortAndPrintChartFive(topFive);
                        break;

                    case EXIT:
                        this.UI.PrintMessage(ON_EXIT_MESSAGE);
                        return;

                    default:

                        if (!this.validator.IsValidUserMove(command))
                        {
                            this.UI.PrintMessage(WRONG_INPUT);
                            break;
                        }

                        var userRow = int.Parse(command[0].ToString());
                        var userColumn = int.Parse(command[2].ToString());

                        // this condition should be a GameLogic method
                        if (game.Field[userRow, userColumn] == 0)
                        {
                            this.UI.PrintMessage(CANNOT_POP_MISSING_BALLOON);
                            continue;
                        }
                        else
                        {
                            // GameLogic.change(game.Field, userRow, userColumn);
                            gameLogicProvider.PopBaloons(game.Field, userRow, userColumn);
                        }

                        game.IncrementMoves();
                        // win condition
                        // GameLogic should have an IsGameWon method
                        if (GameLogic.doit(game.Field))
                        {
                            EndGame(topFive, game.UserMovesCount);
                            // new game
                            game.Reset();
                        }

                        this.UI.PrintField(game.Field);
                        break;
                }
            }
        }

        private void EndGame(string[,] topFive, int userMoves)
        {
            this.UI.PrintMessage(string.Format(WIN_MESSAGE_TEMPLATE, userMoves));

            if (HighScoreUtility.signIfSkilled(topFive, userMoves))
            {
                HighScoreUtility.sortAndPrintChartFive(topFive);
            }
            else
            {
                this.UI.PrintMessage(NOT_IN_TOP_FIVE);
            }
        }

        private string GetTrimmedUppercaseInput()
        {
            var inputAsString = this.UI.ReadUserInput();
            var trimmedUppercaseInput = inputAsString.Trim().ToUpper();

            return trimmedUppercaseInput;
        }
    }
}