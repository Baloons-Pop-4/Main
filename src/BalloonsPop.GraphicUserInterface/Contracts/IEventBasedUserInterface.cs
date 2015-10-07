namespace BalloonsPop.GraphicUserInterface.Contracts
{
    using System;

    using BalloonsPop.Common.Contracts;

    public interface IEventBasedUserInterface : IPrinter
    {
        event EventHandler RaiseCommand;

        void Show();
    }
}
