using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class CommandModule : NinjectModule
    {
        public IKernel Kernel { get; set; } 

        public CommandModule(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public override void Load()
        {
            this.Kernel.Bind<ICommandFactory>().To<CommandFactory>();
        }
    }
}
