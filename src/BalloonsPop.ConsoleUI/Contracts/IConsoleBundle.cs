namespace BalloonsPop.ConsoleUI.Contracts
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    public interface IConsoleBundle : ICoreBundle
    {
        IInputReader Reader { get; set; }
    }
}
