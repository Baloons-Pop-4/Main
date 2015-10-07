namespace BalloonsPop.LogicProvider
{
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;

    /// <summary>
    /// Provides balloon field generation.
    /// </summary>
    internal class FieldGenerator : IBalloonFieldRandomizer
    {
        private const int FieldRows = 4;
        private const int FieldCols = 9;
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
                            x.Number = (byte)this.rng.Next(1, 5); 
                            x.IsPopped = false; 
                        });
        }
    }
}