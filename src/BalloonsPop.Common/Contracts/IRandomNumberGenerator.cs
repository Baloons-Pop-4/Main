namespace BalloonsPop.Common.Contracts
{
    using System;

    /// <summary>
    /// Abstraction for a Random Number Generator.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Defines a public method which should return a byte according to the provided parameters.
        /// </summary>
        /// <param name="min">Minimum value for the result, inclusive.</param>
        /// <param name="max">Maximum vlaue for the result, exclusive.</param>
        /// <returns>A resulting byte in the range [min, max).</returns>
        byte Next(int min, int max);
    }
}
