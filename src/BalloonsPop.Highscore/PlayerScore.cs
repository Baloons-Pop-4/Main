namespace BalloonsPop.Highscore
{
    using System;

    using BalloonsPop.Common.Contracts;

    public class PlayerScore : IPlayerScore
    {
        public string Name { get; set; }
        public int Moves { get; set; }
        public DateTime Time { get; set; }

        public PlayerScore(string name, int moves, DateTime time)
        {
            this.Name = name;
            this.Moves = moves;
            this.Time = time;
        }

        public int CompareTo(IPlayerScore other)
        {
            return this.Moves.CompareTo(other.Moves);
        }
    }
}