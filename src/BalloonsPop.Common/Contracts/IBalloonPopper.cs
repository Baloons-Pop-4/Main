namespace BalloonsPop.Common.Contracts
{
    public interface IBalloonPopper
    {
        void PopBalloons(IBalloon[,] field, int row, int col);
        
        void LetBalloonsFall(IBalloon[,] field);
    }
}