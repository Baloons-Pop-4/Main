namespace BalloonsPop.GameModels
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Balloon : IBalloon
    {
        public byte Number { get; set; }

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