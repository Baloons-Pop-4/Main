namespace BalloonsPop.ConsoleUserInterface.Gadgets
{
    using System;

    using BalloonsPop.Common.Contracts;

    public static class PlayerScoreExtensions
    {
        public static string Stringify(this PlayerScore score, int index)
        {
            return string.Format("{0}.  {1} {2} {3}", index, score.Moves, score.Name, score.Time.ToShortDateString());
        }
    }
}