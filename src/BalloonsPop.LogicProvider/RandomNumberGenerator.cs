namespace BalloonsPop.LogicProvider
{
    using System;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Implement IRandomNumberGenerator and provides random byte values generation.
    /// </summary>
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random rnd = new Random();

        /// <summary>
        /// Generates random byte values in the given range, right inclusive.
        /// </summary>
        /// <param name="min">Minimum for result, inclusive.</param>
        /// <param name="max">Maximum for result, exclusive.</param>
        /// <returns>A random byte number.</returns>
        public byte Next(int min, int max)
        {
            return (byte)this.rnd.Next(min, max);
        }
    }
}
