namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface IPlayerScore : IComparable<IPlayerScore>
    {
        string Name { get; }

        int Moves { get; }

        DateTime Time { get; }
    }
}