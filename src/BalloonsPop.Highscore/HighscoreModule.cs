using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Highscore
{
    using Ninject;

    using BalloonsPop.Common.Contracts;

    public class HighscoreModule : NinjectModule
    {
        private static IKernel kernel;

        public HighscoreModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        public override void Load()
        {
            kernel.Bind<IHighscoreTable>().To<HighscoreTable>();
            kernel.Bind<IPlayerScore>().To<PlayerScore>();
        }
    }
}
