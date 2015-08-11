using System;

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

    public void Initialize(IBaloonsUserInterface UI)
    {
        this.UI = UI;
    }

    public void Run()
    {
        this.Initialize(new ConsoleUI());

        string[,] topFive = new string[5, 2];
        byte[,] matrix = GameLogic.GenerateField();

        this.UI.PrintField(matrix);
        var inputAsString = string.Empty;
        var trimmedUppercaseInput = string.Empty;
        int userMoves = 0;

        while (trimmedUppercaseInput != EXIT)
        {
            this.UI.PrintMessage(MOVE_PROMPT);
            inputAsString = this.UI.ReadUserInput();
            trimmedUppercaseInput = inputAsString.ToUpper().Trim();

            switch (trimmedUppercaseInput)
            {
                case RESTART:
                    matrix = GameLogic.GenerateField();
                    this.UI.PrintField(matrix);
                    userMoves = 0;
                    break;

                case TOP:
                    HighScoreUtility.sortAndPrintChartFive(topFive);
                    break;

                default:
                    if ((trimmedUppercaseInput.Length == 3) && (trimmedUppercaseInput[0] >= '0' && trimmedUppercaseInput[0] <= '9') && (trimmedUppercaseInput[2] >= '0' && trimmedUppercaseInput[2] <= '9') && (trimmedUppercaseInput[1] == ' ' || trimmedUppercaseInput[1] == '.' || trimmedUppercaseInput[1] == ','))
                    {
                        int userRow, userColumn;
                        userRow = int.Parse(trimmedUppercaseInput[0].ToString());
                        if (userRow > 4)
                        {
                            this.UI.PrintMessage(WRONG_INPUT);
                            continue;
                        }
                        userColumn = int.Parse(trimmedUppercaseInput[2].ToString());

                        if (GameLogic.change(matrix, userRow, userColumn))
                        {
                            this.UI.PrintMessage(CANNOT_POP_MISSING_BALLOON);
                            continue;
                        }
                        userMoves++;
                        if (GameLogic.doit(matrix))
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
                            matrix = GameLogic.GenerateField();
                            userMoves = 0;
                        }
                        this.UI.PrintField(matrix);
                        break;
                    }
                    else
                    {
                        this.UI.PrintMessage(WRONG_INPUT);
                        break;
                    }


            }
        }
        this.UI.PrintMessage(ON_EXIT_MESSAGE);
    }
}