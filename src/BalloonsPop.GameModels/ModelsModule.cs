namespace BalloonsPop.GameModels
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// This class inherits the NinjectModule class and provides loading with a provided kernel for the exports of the GameModels module.
    /// </summary>
    public class ModelsModule : NinjectModule
    {
        private static IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsModule" /> class.
        /// </summary>
        /// <param name="bindingKernel"></param>
        public ModelsModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        /// <summary>
        /// Binds the exports of the current module to their respective interfaces.
        /// </summary>
        public override void Load()
        {
            kernel.Unbind<IBalloon>();
            kernel.Unbind<IGameModel>();
            kernel.Bind<IBalloon>().To<Balloon>();
            kernel.Bind<IGameModel>().To<GameModel>();
        }
    }
}
