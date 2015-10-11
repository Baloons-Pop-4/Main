namespace BalloonsPop.Common.Contracts
{
    public interface ICoreBundle
    {   
        /// <summary>
        /// Gets or sets UserInputValidator
        /// </summary>
        IUserInputValidator UserInputValidator { get; set; }

        /// <summary>
        /// Gets or sets a CommandFactory
        /// </summary>
        ICommandFactory CommandFactory { get; set; }

        /// <summary>
        /// Gets or sets a Logger
        /// </summary>
        ILogger Logger { get; set; }
    }
}