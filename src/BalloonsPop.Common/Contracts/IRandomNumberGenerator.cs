namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface IRandomNumberGenerator
    {
        byte Next(int min, int max);
    }
}
