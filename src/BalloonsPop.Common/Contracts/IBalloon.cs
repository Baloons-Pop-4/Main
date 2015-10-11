namespace BalloonsPop.Common.Contracts
{
    public interface IBalloon : ICloneableObject<IBalloon>
    {
        byte Number { get; set; }
        
        bool IsPopped { get; set; }
    }
}