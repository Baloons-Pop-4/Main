namespace BaloonsPop.Common.Contracts
{
    public interface IGameLogicProvider
    {
        // byte[,] GenerateField();
        void RandomizeBaloonField(IBaloonsField field);
        void PopBaloons(IBaloonsField field, IPoint point, IPopPattern pattern);
        void LetBaloonsFall(IBaloonsField field);
        bool GameIsOver(IBaloonsField field);
    }
}
