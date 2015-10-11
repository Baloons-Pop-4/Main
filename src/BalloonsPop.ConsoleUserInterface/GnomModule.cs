namespace BalloonsPop.ConsoleUserInterface
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class GnomModule : NinjectModule
    {
        public GnomModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        public IKernel AppKernel { get; private set; }

        public override void Load()
        {
            this.AppKernel.Unbind<IPrinter>();
            this.AppKernel.Bind<IPrinter>().ToMethod(x => GnomViewProvider.GetController());
        }
    }
}