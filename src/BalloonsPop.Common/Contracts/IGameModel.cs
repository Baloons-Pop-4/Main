namespace BalloonsPop.Common.Contracts
{
    public interface IGameModel
    {
        byte[,] Field { get; set; }
        int UserMovesCount { get; }

        void ResetUserMoves();
        void IncrementMoves();
    }
}