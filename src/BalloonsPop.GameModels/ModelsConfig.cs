using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.GameModels
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class ModelsModule : NinjectModule
    {
        private static IKernel kernel;

        public ModelsModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        public override void Load()
        {
            kernel.Bind<IBalloon>().To<Balloon>();
            kernel.Bind<IGameModel>().To<GameModel>();
        }
    }
}
