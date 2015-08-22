namespace BaloonsPop.Common
{
    using System;
    using BaloonsPop.Common.Contracts;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random randomNumberGenerator;

        public RandomNumberGenerator()
        {
            this.randomNumberGenerator = new Random();
        }

        public int Next(int lowerBound, int upperBound)
        {
            var next = this.randomNumberGenerator.Next(lowerBound, upperBound);
            return next;
        }
    }
}