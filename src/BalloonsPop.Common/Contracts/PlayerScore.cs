namespace BalloonsPop.Common.Contracts
{
    using System;

    public struct PlayerScore : IComparable<PlayerScore>
    {
        public string Name;
        public int Moves;
        public DateTime Time;

        public PlayerScore(string name, int moves, DateTime time)
        {
            this.Name = name;
            this.Moves = moves;
            this.Time = time;
        }

        public int CompareTo(PlayerScore other)
        {
            return this.Moves.CompareTo(other.Moves);
        }
    }
}