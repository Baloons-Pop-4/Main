namespace BaloonsPop.Common.Contracts
{
    public interface IGameLogicProvider
    {
        byte[,] GenerateField();
        void PopBaloons(byte[,] field, int row, int col);
        void LetBaloonsFall(byte[,] field);
        bool GameIsOver(byte[,] field);
    }
}
