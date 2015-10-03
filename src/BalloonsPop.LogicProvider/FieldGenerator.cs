namespace BalloonsPop.LogicProvider
{
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;

    internal class FieldGenerator : IBalloonFieldGenerator
    {
        private const int FieldRows = 4;
        private const int FieldCols = 9;
        private const int MinBalloonValue = 1;
        private const int MaxBalloonValue = 4;

        private readonly IRandomNumberGenerator rng;

        public FieldGenerator(IRandomNumberGenerator rng)
        {
            this.rng = rng;
        }

        public IBalloon[,] GenerateField()
        {
            var field = new QueriableMatrix<IBalloon>(new IBalloon[FieldRows + 1, FieldCols + 1])
                            .Select(x => this.GetRandomBalloonValue())
                            .ToMatrix(FieldRows + 1, FieldCols + 1);

            return field;
        }

        private IBalloon GetRandomBalloonValue()
        {
            var randomBalloonValue = (byte)this.rng.Next(MinBalloonValue, MaxBalloonValue + 1);
            return new Balloon() { Number = randomBalloonValue };
        }
    }
}