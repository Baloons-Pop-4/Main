namespace BaloonsPop.Common.Contracts
{
    public interface IGameModel
    {
        IBaloonsField Field { get; }
        int UserMovesCount { get; }

        void IncrementMoves();
    }
}