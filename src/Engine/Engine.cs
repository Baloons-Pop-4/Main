using System;

using Contracts;

public class Engine : IEngine
{
    // Singleton design pattern

    public static Engine Instance = new Engine();

    private Engine()
    {

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
        IBaloonsUserInterface logger = new ConsoleUI();

        string[,] topFive = new string[5, 2];
        byte[,] matrix = GameLogic.GenerateField();

        logger.PrintField(matrix);
        string temp = null;
        int userMoves = 0;
        while (temp != "EXIT")
        {
            logger.PrintMessage("Enter a row and column: ");
            temp = Console.ReadLine();
            temp = temp.ToUpper().Trim();

            switch (temp)
            {
                case "RESTART":
                    matrix = GameLogic.GenerateField();
                    logger.PrintField(matrix);
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
                            logger.PrintMessage("Wrong input ! Try Again ! ");
                            continue;
                        }
                        userColumn = int.Parse(temp[2].ToString());

                        if (GameLogic.change(matrix, userRow, userColumn))
                        {
                            logger.PrintMessage("cannot pop missing ballon!");
                            continue;
                        }
                        userMoves++;
                        if (GameLogic.doit(matrix))
                        {
                            logger.PrintMessage(string.Format("Gratz ! You completed it in {0} moves.", userMoves));
                            if (HighScoreUtility.signIfSkilled(topFive, userMoves))
                            {
                                HighScoreUtility.sortAndPrintChartFive(topFive);
                            }
                            else
                            {
                                logger.PrintMessage("I am sorry you are not skillful enough for TopFive chart!");
                            }
                            matrix = GameLogic.GenerateField();
                            userMoves = 0;
                        }
                        logger.PrintField(matrix);
                        break;
                    }
                    else
                    {
                        logger.PrintMessage("Wrong input ! Try Again ! ");
                        break;
                    }


            }
        }
        Console.WriteLine("Good Bye! ");
    }
}