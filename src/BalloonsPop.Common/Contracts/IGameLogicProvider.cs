namespace BalloonsPop.Common.Contracts
{
    public interface IGameLogicProvider : IBalloonFieldRandomizer, IBalloonPopper
    {
        bool GameIsOver(IBalloon[,] field);
    }    
}