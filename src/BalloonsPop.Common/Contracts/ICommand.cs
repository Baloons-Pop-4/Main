namespace BalloonsPop.Common.Contracts
{
    public interface ICommand
    {
        void Execute(IContext context);
    }
}