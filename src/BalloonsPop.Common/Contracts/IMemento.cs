namespace BalloonsPop.Common.Contracts
{
    public interface IMemento<T>
    {
        T State { get; set; }
    }
}
