namespace BalloonsPop.ConsoleUserInterface.Gadgets
{
    using System;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides extensions methods for the PlayerScore struct.
    /// </summary>
    public static class PlayerScoreExtensions
    {
        /// <summary>
        /// Converts an instance of the PlayerScore struct to a string.
        /// </summary>
        /// <param name="score"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string Stringify(this PlayerScore score, int index)
        {
            return string.Format("{0}.  {1} {2} {3}", index, score.Moves, score.Name, score.Time.ToShortDateString());
        }
    }
}