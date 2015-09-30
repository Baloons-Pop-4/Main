using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.ConsoleUI.Contracts
{
    using BalloonsPop.Common.Contracts;

    public interface IConsoleBundle : ICoreBundle
    {
        IInputReader Reader { get; set; }
    }
}
