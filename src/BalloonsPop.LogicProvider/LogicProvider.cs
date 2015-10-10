namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    /// <summary>
    /// Implements IGameLogicProvider and defines operation on IGameModel type and it's properties and provides instances access to them.
    /// </summary>
    public class LogicProvider : IGameLogicProvider
    {
        private readonly IBalloonFieldRandomizer fieldRandomizer;

        private readonly IBalloonPopper balloonPopper;

        /// <summary>
        /// Public constructor that initializes the current instance with matrix validator and random number generator.
        /// </summary>
        /// <param name="matrixValidator">The matrix validator.</param>
        /// <param name="rng">The random byte generator.</param>
        public LogicProvider(IMatrixValidator matrixValidator, IRandomNumberGenerator rng)
        {
            this.balloonPopper = new BalloonPopper(matrixValidator);
            this.fieldRandomizer = new FieldGenerator(rng);
        }

        /// <summary>
        /// Provides randomization of a balloon field represented as two-dimensional array.
        /// </summary>
        /// <param name="field">The array representation of a game field.</param>
        public void RandomizeBalloonField(IBalloon[,] field)
        {
            this.fieldRandomizer.RandomizeBalloonField(field);
        }

        /// <summary>
        /// Provides popping logic based on field, row and column.
        /// </summary>
        /// <param name="field">Array representation of the game field.</param>
        /// <param name="row">The number of rows in the field.</param>
        /// <param name="column">The number of columns in the field.</param>
        public void PopBalloons(IBalloon[,] field, int row, int column)
        {
            this.balloonPopper.PopBalloons(field, row, column);
        }

        /// <summary>
        /// Moves all non-popped balloons vertically to the bottom of the array, effectively simulating gravity.
        /// </summary>
        /// <param name="field">Array representation of the game field.</param>
        public void LetBalloonsFall(IBalloon[,] field)
        {
            this.balloonPopper.LetBalloonsFall(field);
        }

        /// <summary>
        /// Determines whether a game is over.
        /// </summary>
        /// <param name="matrix">Array representation of the game field.</param>
        /// <returns>Returns whether there remains at least one unpopped balloon.</returns>
        public bool GameIsOver(IBalloon[,] matrix)
        {
            var fieldIsEmpty = new QueryableMatrix<IBalloon>(matrix).All(balloon => balloon.IsPopped);

            return fieldIsEmpty;
        }
    }
}