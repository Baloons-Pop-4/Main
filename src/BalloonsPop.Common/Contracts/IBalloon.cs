namespace BalloonsPop.Common.Contracts
{
    public interface IBalloon
    {
        byte Number { get; set; }
        bool isPopped { get; set; }
    }
}
