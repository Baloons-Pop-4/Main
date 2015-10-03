namespace BalloonsPop.Highscore
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Highscore.HighscoreHandlingStrategies;

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
            kernel.Bind<IHighscoreHandlingStrategy>().To<XmlHandlingStrategy>();
            kernel.Bind<IHighscoreTable>().ToMethod(x => kernel.Get<IHighscoreHandlingStrategy>().Load());
        }
    }
}
