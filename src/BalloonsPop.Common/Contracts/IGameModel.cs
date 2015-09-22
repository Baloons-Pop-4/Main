namespace BalloonsPop.Common.Contracts
{
    public interface IGameModel : ICloneableObject<IGameModel>
    {
        IBalloon[,] Field { get; set; }
        int UserMovesCount { get; }

        void ResetUserMoves();
        void IncrementMoves();
    }
}