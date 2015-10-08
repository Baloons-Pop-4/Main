namespace BalloonsPop.Core.Gadgets
{
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    internal static class IGameModelExtensions
    {
        public static IBalloon At(this IGameModel gameModel, string coordinatesAsString)
        {
            var digitsInCoordinates = coordinatesAsString.Where(x => char.IsDigit(x)).ToArray();

            if(digitsInCoordinates.Length !=2)
            {
                return null;
            }

            return gameModel.Field[digitsInCoordinates[0].ToInt32(), digitsInCoordinates[1].ToInt32()];
        }
    }
}
