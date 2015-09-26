using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.LogicProvider
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class LogicModule : NinjectModule
    {
        // private static IKernel kernel = new StandardKernel();

        private static IKernel kernel;

        public LogicModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        public override void Load()
        {
            kernel.Bind<IGameLogicProvider>().To<LogicProvider>();
        }
    }
}
