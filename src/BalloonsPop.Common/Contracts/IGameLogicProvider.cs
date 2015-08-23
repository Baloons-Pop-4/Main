namespace BalloonsPop.Common.Contracts
{
    public interface IGameLogicProvider
    {
        byte[,] GenerateField();
        void PopBalloons(byte[,] field, int row, int col);
        void LetBalloonsFall(byte[,] field);
        bool GameIsOver(byte[,] field);
    }
}
