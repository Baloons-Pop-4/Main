namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface IPlayerScore : IComparable<IPlayerScore>
    {
        string Name { get; set; }
        int Moves { get; set; }
        DateTime Time { get; set; }
    }
}