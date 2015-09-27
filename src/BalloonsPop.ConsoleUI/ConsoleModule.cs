namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class ConsoleModule : NinjectModule
    {
        public IInputReader Reader { get; set; }
        public IPrinter Prinet { get; set; }

        public IKernel Kernel { get; set; } 

        public ConsoleModule(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public override void Load()
        {
            this.Kernel.Bind<IInputReader>().To<ConsoleUI>();
            this.Kernel.Bind<IPrinter>().To<ConsoleUI>();
        }
    }
}
