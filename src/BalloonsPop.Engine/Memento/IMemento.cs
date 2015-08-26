namespace BalloonsPop.Engine.Memento
{
    public interface IMemento<T>
    {
        T State { get; set; }
    }
}
