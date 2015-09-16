namespace BalloonsPop.Engine
{
    using System;

    public struct PlayerScore : IComparable<PlayerScore>
    {
        public int Value;
        public string Name;

        public PlayerScore(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public int CompareTo(PlayerScore other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}