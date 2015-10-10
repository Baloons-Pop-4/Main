namespace BalloonsPop.LogicProvider
{
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    /// <summary>
    /// Provides balloon field generation.
    /// </summary>
    internal class FieldGenerator : IBalloonFieldRandomizer
    {
        private const int MinBalloonValue = 1;
        private const int MaxBalloonValue = 4;

        private readonly IRandomNumberGenerator rng;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldGenerator"/> class.
        /// </summary>
        /// <param name="rng">An object that provides generation of pseudo-random integers.</param>
        public FieldGenerator(IRandomNumberGenerator rng)
        {
            this.rng = rng;
        }

        /// <summary>
        /// Generates a random matrix of balloons that are not popped.
        /// </summary>
        /// <param name="field">The field.</param>
        public void RandomizeBalloonField(IBalloon[,] field)
        {
            new QueryableMatrix<IBalloon>(field)
                .ForEach(x =>
                        {
                            x.Number = this.rng.Next(MinBalloonValue, MaxBalloonValue + 1);
                            x.IsPopped = false;
                        });
        }
    }
}