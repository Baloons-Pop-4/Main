namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Abstraction of an object type dedicated to providing game models manipulation logic.
    /// </summary>
    public interface IGameLogicProvider : IBalloonFieldRandomizer, IBalloonPopper
    {
        /// <summary>
        /// Defines the operation of verifying whether a game is over in an abstract way.
        /// </summary>
        /// <param name="field">The balloon field to check against.</param>
        /// <returns>True is the game is over, false otherwise.</returns>
        bool GameIsOver(IBalloon[,] field);
    }    
}