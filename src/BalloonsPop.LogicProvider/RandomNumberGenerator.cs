namespace BalloonsPop.LogicProvider
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random rnd = new Random();

        public int Next(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
