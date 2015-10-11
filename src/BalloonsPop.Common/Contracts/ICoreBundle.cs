namespace BalloonsPop.Common.Contracts
{
    public interface ICoreBundle
    {        
        IUserInputValidator UserInputValidator { get; set; }

        ICommandFactory CommandFactory { get; set; }

        ILogger Logger { get; set; }
    }
}