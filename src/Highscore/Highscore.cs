namespace Highscore
{
    using System;
    using System.Collections.Generic;

    public class HighScoreUtility
    {
        private static readonly  int TOP_FIVE_NUMBER = 5;

        public static void SortAndPrintChartFive(string[,] scoresToAdd)
        {
            List<PlayerScore> currentScore = new List<PlayerScore>();

            for (int i = 0; i < TOP_FIVE_NUMBER; i++)
            {
                if (scoresToAdd[i, 0] == null)
                {
                    break;
                }

                currentScore.Add(new PlayerScore(int.Parse(scoresToAdd[i, 0]), scoresToAdd[i, 1]));
            }

            currentScore.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");

            for (int i = 0; i < currentScore.Count; ++i)
            {
                PlayerScore slot = currentScore[i];
                Console.WriteLine("{0}.   {1} with {2} moves.", i + 1, slot.Name, slot.Score);
            }

            Console.WriteLine("----------------------------------");
        }

        public static bool signIfSkilled(string[,] chart, int points)
        {
            bool skilled = false;
            int worstScore = 0;
            int worstScoreChartPosition = 0;

            for (int i = 0; i < 5; i++)
            {
                if (chart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string userName = Console.ReadLine();

                    chart[i, 0] = points.ToString();
                    chart[i, 1] = userName;
                    skilled = true;

                    break;
                }
            }

            if (skilled == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(chart[i, 0]) > worstScore)
                    {
                        worstScoreChartPosition = i;
                        worstScore = int.Parse(chart[i, 0]);
                    }
                }
            }

            if (points < worstScore && skilled == false)
            {
                Console.WriteLine("Type in your name.");
                string userName = Console.ReadLine();

                chart[worstScoreChartPosition, 0] = points.ToString();
                chart[worstScoreChartPosition, 1] = userName;
                skilled = true;
            }

            return skilled;
        }
    }
}