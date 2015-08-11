﻿namespace Engine
{
    using System;

    using Contracts;
    using Highscore;

    internal class Game
    {
        private byte[,] field;

        private int userMovesCount;

        public Game()
        {
            this.Reset();
        }

        public byte[,] Field
        {
            get
            {
                return this.field;
            }
        }

        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        public void Reset()
        {
            this.field = GameLogic.GenerateField();
            this.userMovesCount = 0;
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }
    }

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

        HighScoreUtility highScore = new HighScoreUtility();

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
            var game = new Game();

            this.UI.PrintField(game.Field);
            var command = string.Empty;

            while (command != EXIT)
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
                        highScore.SortAndPrintChartFive(topFive);
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
                            GameLogic.change(game.Field, userRow, userColumn);
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

            if (highScore.SignIfSkilled(topFive, userMoves))
            {
                highScore.SortAndPrintChartFive(topFive);
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