namespace BalloonsPop.Common.Contracts
{
    public interface IGameLogicProvider : IBalloonFieldRandomizer, IBalloonPopper
    {
        bool GameIsOver(IBalloon[,] field);
    }

    public interface IBalloonFieldRandomizer
    {
        void RandomizeBalloonField(IBalloon[,] field);
    }

    public interface IBalloonPopper
    {
        void PopBalloons(IBalloon[,] field, int row, int col);
        
        void LetBalloonsFall(IBalloon[,] field);
    }
}