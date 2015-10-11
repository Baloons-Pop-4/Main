namespace BalloonsPop.GameModels
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Balloon : IBalloon
    {
        /// <summary>
        /// Gets or sets the balloon's number
        /// </summary>
        public byte Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the balloon is popped
        /// </summary>
        public bool IsPopped { get; set; }

        public IBalloon Clone()
        {
            return new Balloon()
            {
                Number = this.Number,
                IsPopped = this.IsPopped
            };
        }
    }
}