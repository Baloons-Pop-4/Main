namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Defines the properties that a balloon model should implement.
    /// </summary>
    public interface IBalloon : ICloneableObject<IBalloon>
    {
        /// <summary>
        /// Gets or sets a balloon number
        /// </summary>
        byte Number { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the balloon is popped
        /// </summary>
        bool IsPopped { get; set; }
    }
}