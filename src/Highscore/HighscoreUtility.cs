namespace Highscore
{
    using System;
    using System.Collections.Generic;

    public class HighScoreUtility : IHighScoreUtility
    {
        private const int TOP_FIVE_NUMBER = 5;

        public void SortAndPrintChartFive(string[,] scoresToAdd)
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
                PlayerScore currentPlayer = currentScore[i];
                Console.WriteLine("{0}.   {1} with {2} moves.", i + 1, currentPlayer.Name, currentPlayer.Score);
            }

            Console.WriteLine("----------------------------------");
        }

        public bool SignIfSkilled(string[,] chart, int points)
        {
            bool isSkilled = false;
            int worstScore = 0;
            int worstScoreChartPosition = 0;

            for (int i = 0; i < 5; i++)
            {
                if (chart[i, 0] == null)
                {
                    //Console.Write("Type in your name: ");
                    //string userName = Console.ReadLine();

                    //chart[i, 0] = points.ToString();
                    //chart[i, 1] = userName;

                    SignNewPlayer(chart, points, i);
                    isSkilled = true;

                    break;
                }
            }

            if (isSkilled == false)
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

            if (points < worstScore && isSkilled == false)
            {
                //Console.Write("Type in your name: ");
                //string userName = Console.ReadLine();

                //chart[worstScoreChartPosition, 0] = points.ToString();
                //chart[worstScoreChartPosition, 1] = userName;

                SignNewPlayer(chart, points, worstScoreChartPosition);
                isSkilled = true;
            }

            return isSkilled;
        }

        public void SignNewPlayer(string[,] chart, int points, int index)
        {
            Console.Write("Type in your name: ");
            string userName = Console.ReadLine();

            chart[index, 0] = points.ToString();
            chart[index, 1] = userName;
        }
    }
}