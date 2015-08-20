namespace BaloonsPop.GraphicUserInterface
{
    using System;

    using BaloonsPop.Common.Contracts;

    public interface IEventBasedUserInterface : IUserInterface
    {
        event EventHandler Raise;
    }
}
