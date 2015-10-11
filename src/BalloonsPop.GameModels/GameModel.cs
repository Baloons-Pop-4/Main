namespace BalloonsPop.GameModels
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class GameModel : IGameModel
    {
        private IBalloon[,] field;

        private int userMovesCount;

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

        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        public void ResetUserMoves()
        {
            this.userMovesCount = 0;
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }

        public IGameModel Clone()
        {
            var clonedField = new QueryableMatrix<IBalloon>(this.field)
                                        .Select(balloon => balloon.Clone())
                                        .ToMatrix(this.field.GetLength(0), this.field.GetLength(1));

            return new GameModel() { field = clonedField };
        }
    }
}