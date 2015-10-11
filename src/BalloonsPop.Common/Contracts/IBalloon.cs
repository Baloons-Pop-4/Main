namespace BalloonsPop.Common.Contracts
{
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