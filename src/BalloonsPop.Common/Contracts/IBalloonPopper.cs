namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides an abstraction for an implementation of balloon popping in a field.
    /// </summary>
    public interface IBalloonPopper
    {
        /// <summary>
        /// Defines popping balloons in a balloon field by given row and column.
        /// </summary>
        /// <param name="field">The provided balloon field.</param>
        /// <param name="row">The provided row.</param>
        /// <param name="col">The provided column</param>
        void PopBalloons(IBalloon[,] field, int row, int col);
        
        /// <summary>
        /// Defines a kind of "gravity" i.e. letting the balloons fall to the bottom of the field.
        /// </summary>
        /// <param name="field">The provided balloon field.</param>
        void LetBalloonsFall(IBalloon[,] field);
    }
}