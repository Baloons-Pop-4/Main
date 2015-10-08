namespace BalloonsPop.LogicProvider
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// This class inherits the NinjectModule class and provides loading with a provided kernel for the exports of the logic provider project.
    /// </summary>
    public class LogicModule : NinjectModule
    {
        private static IKernel kernel;

        /// <summary>
        /// Public constructor which initializes the current instance with the provided kernel.
        /// </summary>
        /// <param name="bindingKernel"></param>
        public LogicModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        /// <summary>
        /// This overload of the method Load provides binding for the project exports.
        /// </summary>
        public override void Load()
        {
            kernel.Bind<IGameLogicProvider>().To<LogicProvider>();
            kernel.Bind<IRandomNumberGenerator>().To<RandomNumberGenerator>();
        }
    }
}
