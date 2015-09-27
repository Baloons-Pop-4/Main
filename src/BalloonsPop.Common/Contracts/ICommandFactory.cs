namespace BalloonsPop.Common.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}