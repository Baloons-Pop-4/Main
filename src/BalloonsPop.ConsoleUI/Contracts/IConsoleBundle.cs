namespace BalloonsPop.ConsoleUI.Contracts
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    public interface IConsoleBundle : ICoreBundle
    {
        /// <summary>
        /// Gets or sets a Reader
        /// </summary>
        IInputReader Reader { get; set; }
    }
}
