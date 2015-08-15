namespace Highscore
{
    interface IHighScoreUtility
    {
        void SortAndPrintChartFive(string[,] scoresToAdd);

        bool SignIfSkilled(string[,] chart, int points);

        void SignNewPlayer(string[,] chart, int points, int index);
    }
}
