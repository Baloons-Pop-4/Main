namespace BalloonsPop.GameModels
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    /// <summary>
    /// Models the game by encapsulating a balloon field and information about user moves.
    /// </summary>
    public class GameModel : IGameModel
    {
        private IBalloon[,] field;

        private int userMovesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel" /> class.
        /// </summary>
        /// <param name="balloonFiller"></param>
        public GameModel(IBalloon balloonFiller = null)
        {
            if (balloonFiller == null)
            {
                balloonFiller = new Balloon();
            }

            this.field = new QueryableMatrix<IBalloon>(5, 10).Select(x =>
                                                                {
                                                                    var balloon = balloonFiller.Clone();
                                                                    balloon.IsPopped = false;
                                                                    return balloon;
                                                                })
                                                                .ToMatrix(5, 10);
                                                                this.userMovesCount = 0;
        }

        /// <summary>
        /// Gets or sets a Balloon field
        /// </summary>
        public IBalloon[,] Field
        {
            get
            {
                return this.field;
            }

            set
            {
                // TODO: validations here, logging here
                this.field = value;
            }
        }

        /// <summary>
        /// Gets the user's moves count
        /// </summary>
        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        /// <summary>
        /// Zeroes the moves in the current game.
        /// </summary>
        public void ResetUserMoves()
        {
            this.userMovesCount = 0;
        }

        /// <summary>
        /// Increments the moves in the current game by one.
        /// </summary>
        public void IncrementMoves()
        {
            this.userMovesCount++;
        }

        /// <summary>
        /// Provides a deep clone of the current instance.
        /// </summary>
        /// <returns></returns>
        public IGameModel Clone()
        {
            var clonedField = new QueryableMatrix<IBalloon>(this.field)
                                        .Select(balloon => balloon.Clone())
                                        .ToMatrix(this.field.GetLength(0), this.field.GetLength(1));

            return new GameModel() { field = clonedField };
        }
    }
}