namespace BalloonsPop.Common.Contracts
{
    using System;
    public interface IRandomNumberGenerator
    {
        int Next(int min, int max);
    }
}
