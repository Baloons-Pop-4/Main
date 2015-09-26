namespace BalloonsPop.GraphicUserInterface
{
    using System;

    using BalloonsPop.Common.Contracts;

    public interface IEventBasedUserInterface : IPrinter
    {
        event EventHandler Raise;

        void Show();
    }
}
