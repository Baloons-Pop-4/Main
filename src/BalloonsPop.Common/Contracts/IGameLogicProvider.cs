namespace BalloonsPop.Common.Contracts
{
    public interface IGameLogicProvider
    {
        IBalloon[,] GenerateField();
        void PopBalloons(IBalloon[,] field, int row, int col);
        void LetBalloonsFall(IBalloon[,] field);
        bool GameIsOver(IBalloon[,] field);
    }
}
