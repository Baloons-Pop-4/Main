namespace BalloonsPop.GameModels
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Balloon : IBalloon
    {
        public byte Number { get; set; }

        public bool isPopped { get; set; }
    }
}