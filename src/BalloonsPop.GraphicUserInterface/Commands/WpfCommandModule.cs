using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Common.Contracts;
using BalloonsPop.Core.Commands;
using Ninject;

namespace BalloonsPop.GraphicUserInterface.Commands
{
    public class WpfCommandModule : CommandModule
    {
        public WpfCommandModule(IKernel kernel)
            : base(kernel)
        { }

        public override void Load()
        {
            this.AppKernel.Bind<ICommandFactory>().ToMethod(x =>
            {
                var newCmdFactory = new CommandFactory();

                newCmdFactory.UnregisterCommand("exit"); 
                newCmdFactory.RegisterCommand("exit", () => new WpfExitCommand());
 
                return newCmdFactory;
            });
        }
    }
}
