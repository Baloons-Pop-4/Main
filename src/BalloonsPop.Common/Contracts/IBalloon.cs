namespace BalloonsPop.Common.Contracts
{
    public interface IBalloon
    {
        byte Number { get; set; }
        bool IsPopped { get; set; }
    }
}
