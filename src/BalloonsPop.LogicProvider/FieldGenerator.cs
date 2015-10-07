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
        /// Constructor for the FieldGenerator class.
        /// </summary>
        /// <param name="rng">An object that provides generation of pseudo-random integers.</param>
        public FieldGenerator(IRandomNumberGenerator rng)
        {
            this.rng = rng;
        }

        /// <summary>
        /// Generates a random matrix of balloons that are not popped.
        /// </summary>
        /// <returns></returns>
        public void RandomizeBalloonField(IBalloon[,] field)
        {
            new QueriableMatrix<IBalloon>(field)
                .ForEach(x => 
                        { 
                            x.Number = this.rng.Next(MinBalloonValue, MaxBalloonValue + 1); 
                            x.IsPopped = false; 
                        });
        }
    }
}