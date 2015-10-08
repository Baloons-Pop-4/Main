using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Common.Contracts;

namespace BalloonsPop.Core.Commands
{
    public class CompositeUndoCommand : CompositeCommand
    {
        public CompositeUndoCommand()
        {
            this.SubCommands = new List<ICommand>() 
            {
                new UndoCommand(),
                new PrintFieldCommand()
            };
        }
    }
}
