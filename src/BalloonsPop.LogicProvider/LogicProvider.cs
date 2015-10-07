namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class LogicProvider : IGameLogicProvider
    {
        private static readonly int[][] PopDirections = new int[][]
        { 
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };

        private readonly IBalloonFieldRandomizer fieldRandomizer;

        private readonly IBalloonPopper balloonPopper;

        public LogicProvider(IMatrixValidator matrixValidator, IRandomNumberGenerator rng)
        {
            this.balloonPopper = new BalloonPopper(matrixValidator);
            this.fieldRandomizer = new FieldGenerator(rng);
        }

        public void RandomizeBalloonField(IBalloon[,] field)
        {
            this.fieldRandomizer.RandomizeBalloonField(field);
        }

        public void PopBalloons(IBalloon[,] field, int row, int column)
        {
            this.balloonPopper.PopBalloons(field, row, column);
        }

        public void LetBalloonsFall(IBalloon[,] field)
        {
            this.balloonPopper.LetBalloonsFall(field);
        }

        public bool GameIsOver(IBalloon[,] matrix)
        {
            var fieldIsEmpty = new QueriableMatrix<IBalloon>(matrix).All(balloon => balloon.IsPopped);

            return fieldIsEmpty;
        }
    }
}