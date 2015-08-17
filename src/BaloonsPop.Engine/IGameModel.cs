namespace BaloonsPop.Engine
{
    public interface IGameModel
    {
        byte[,] Field { get; }
        int UserMovesCount { get; }

        void Reset();
        void IncrementMoves();
    }
}