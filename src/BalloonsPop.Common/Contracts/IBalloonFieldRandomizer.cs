namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for field randomization.
    /// </summary>
    public interface IBalloonFieldRandomizer
    {
        /// <summary>
        /// Randomizes a provided balloon field.
        /// </summary>
        /// <param name="field">The balloon field to be randomized.</param>
        void RandomizeBalloonField(IBalloon[,] field);
    }
}