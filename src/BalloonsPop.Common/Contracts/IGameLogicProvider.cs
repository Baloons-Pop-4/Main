namespace BalloonsPop.Common.Contracts
{
    public interface IGameLogicProvider : IBalloonFieldGenerator, IBalloonPopper
    {
        bool GameIsOver(IBalloon[,] field);
    }

    public interface IBalloonFieldGenerator
    {
        IBalloon[,] GenerateField();
    }

    public interface IBalloonPopper
    {
        void PopBalloons(IBalloon[,] field, int row, int col);
        void LetBalloonsFall(IBalloon[,] field);
    }
}