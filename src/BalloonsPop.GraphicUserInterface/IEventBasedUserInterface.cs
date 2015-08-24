namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Common.Contracts;

    public interface IEventBasedUserInterface : IUserInterface
    {
        event EventHandler Raise;
    }
}
