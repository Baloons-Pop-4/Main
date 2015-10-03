namespace BalloonsPop.Highscore
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

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
            kernel.Bind<IHighscoreSaver>().ToMethod(c => HighscoreSaver.GetInstance(c.Kernel));
        }
    }
}
