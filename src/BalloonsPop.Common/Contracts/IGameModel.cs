namespace BalloonsPop.Common.Contracts
{
    public interface IGameModel : ICloneableObject<IGameModel>
    {
        /// <summary>
        /// Gets or sets a balloon field
        /// </summary>
        IBalloon[,] Field { get; set; }
        
        /// <summary>
        /// Gets user's moves count
        /// </summary>
        int UserMovesCount { get; }

        void ResetUserMoves();
        
        void IncrementMoves();
    }
}