namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Provides abstract definition of a game model.
    /// </summary>
    public interface IGameModel : ICloneableObject<IGameModel>
    {
        /// <summary>
        /// Gets or sets a balloon field.
        /// </summary>
        IBalloon[,] Field { get; set; }
        
        /// <summary>
        /// Gets user's moves count.
        /// </summary>
        int UserMovesCount { get; }

        /// <summary>
        /// Abstracts the resetting of user moves in the model.
        /// </summary>
        void ResetUserMoves();
        
        /// <summary>
        /// Abstracts the incrementation of user moves in the model.
        /// </summary>
        void IncrementMoves();
    }
}