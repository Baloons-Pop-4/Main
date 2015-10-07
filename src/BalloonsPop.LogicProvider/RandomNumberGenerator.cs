namespace BalloonsPop.LogicProvider
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random rnd = new Random();

        public byte Next(int min, int max)
        {
            return (byte)this.rnd.Next(min, max);
        }
    }
}
