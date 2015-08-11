using System;

using Contracts;

public class Engine : IEngine
{
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

    //public void Run()
    //{
    //    string[,] topFive = new string[5, 2];
    //    byte[,] matrix = GameLogic.GenerateField(5, 10);

    //    GameLogic.printMatrix(matrix);
    //    string temp = null;
    //    int userMoves = 0;
    //    while (temp != "EXIT")
    //    {
    //        Console.WriteLine("Enter a row and column: ");
    //        temp = Console.ReadLine();
    //        temp = temp.ToUpper().Trim();

    //        switch (temp)
    //        {
    //            case "RESTART":
    //                matrix = GameLogic.GenerateField(5, 10);
    //                GameLogic.printMatrix(matrix);
    //                userMoves = 0;
    //                break;

    //            case "TOP":
    //                HighScoreUtility.sortAndPrintChartFive(topFive);
    //                break;

    //            default:
    //                if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
    //                {
    //                    int userRow, userColumn;
    //                    userRow = int.Parse(temp[0].ToString());
    //                    if (userRow > 4)
    //                    {
    //                        Console.WriteLine("Wrong input ! Try Again ! ");
    //                        continue;
    //                    }
    //                    userColumn = int.Parse(temp[2].ToString());

    //                    if (GameLogic.change(matrix, userRow, userColumn))
    //                    {
    //                        Console.WriteLine("cannot pop missing ballon!");
    //                        continue;
    //                    }
    //                    userMoves++;
    //                    if (GameLogic.doit(matrix))
    //                    {
    //                        Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
    //                        if (HighScoreUtility.signIfSkilled(topFive, userMoves))
    //                        {
    //                            HighScoreUtility.sortAndPrintChartFive(topFive);
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
    //                        }
    //                        matrix = GameLogic.GenerateField(5, 10);
    //                        userMoves = 0;
    //                    }
    //                    GameLogic.printMatrix(matrix);
    //                    break;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Wrong input ! Try Again ! ");
    //                    break;
    //                }


    //        }
    //    }
    //    Console.WriteLine("Good Bye! ");
    //}
    public void Run()
    {
        this.Initialize(new ConsoleUI());

        string[,] topFive = new string[5, 2];
        byte[,] matrix = GameLogic.GenerateField();

        this.UI.PrintField(matrix);
        string temp = null;
        int userMoves = 0;
        while (temp != "EXIT")
        {
            this.UI.PrintMessage("Enter a row and column: ");
            temp = Console.ReadLine();
            temp = temp.ToUpper().Trim();

            switch (temp)
            {
                case "RESTART":
                    matrix = GameLogic.GenerateField();
                    this.UI.PrintField(matrix);
                    userMoves = 0;
                    break;

                case "TOP":
                    HighScoreUtility.sortAndPrintChartFive(topFive);
                    break;

                default:
                    if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                    {
                        int userRow, userColumn;
                        userRow = int.Parse(temp[0].ToString());
                        if (userRow > 4)
                        {
                            this.UI.PrintMessage("Wrong input ! Try Again ! ");
                            continue;
                        }
                        userColumn = int.Parse(temp[2].ToString());

                        if (GameLogic.change(matrix, userRow, userColumn))
                        {
                            this.UI.PrintMessage("cannot pop missing ballon!");
                            continue;
                        }
                        userMoves++;
                        if (GameLogic.doit(matrix))
                        {
                            this.UI.PrintMessage(string.Format("Gratz ! You completed it in {0} moves.", userMoves));
                            if (HighScoreUtility.signIfSkilled(topFive, userMoves))
                            {
                                HighScoreUtility.sortAndPrintChartFive(topFive);
                            }
                            else
                            {
                                this.UI.PrintMessage("I am sorry you are not skillful enough for TopFive chart!");
                            }
                            matrix = GameLogic.GenerateField();
                            userMoves = 0;
                        }
                        this.UI.PrintField(matrix);
                        break;
                    }
                    else
                    {
                        this.UI.PrintMessage("Wrong input ! Try Again ! ");
                        break;
                    }


            }
        }
        Console.WriteLine("Good Bye! ");
    }
}