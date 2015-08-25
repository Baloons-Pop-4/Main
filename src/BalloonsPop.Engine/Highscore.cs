namespace BalloonsPop.Engine
{
    using System;
    using System.Collections.Generic;

    public class HighScoreUtility
    {
        public static void SortAndPrintChartFive(string[,] tableToSort)
        {
            List<PlayerScore> klasirane = new List<PlayerScore>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                klasirane.Add(new PlayerScore(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));
            }

            klasirane.Sort();

            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < klasirane.Count; ++i)
            {
                PlayerScore slot = klasirane[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }

            Console.WriteLine("----------------------------------");
        }

        public static bool SignIfSkilled(string[,] chart, int points)
        {
            bool skilled = false;
            int worstMoves = 0;
            int worstMovesChartPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string tempUserName = Console.ReadLine();
                    chart[i, 0] = points.ToString();
                    chart[i, 1] = tempUserName;
                    skilled = true;
                    break;
                }
            }

            if (skilled == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(chart[i, 0]) > worstMoves)
                    {
                        worstMovesChartPosition = i;
                        worstMoves = int.Parse(chart[i, 0]);
                    }
                }
            }

            if (points < worstMoves && skilled == false)
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                chart[worstMovesChartPosition, 0] = points.ToString();
                chart[worstMovesChartPosition, 1] = tempUserName;
                skilled = true;
            }

            return skilled;
        }
    }
}