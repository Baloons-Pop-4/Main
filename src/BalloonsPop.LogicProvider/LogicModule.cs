namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

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
            kernel.Bind<IRandomNumberGenerator>().To<RandomNumberGenerator>();
        }
    }
}
