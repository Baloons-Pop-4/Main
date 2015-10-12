namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Abstracts the signature of an object type containing the core dependencies for the EngineCore.
    /// </summary>
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