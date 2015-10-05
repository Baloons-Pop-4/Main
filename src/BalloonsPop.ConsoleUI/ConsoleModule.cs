namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class ConsoleModule : NinjectModule
    {
        public ConsoleModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        public IKernel AppKernel { get; set; } 

        public override void Load()
        {
            var consoleUi = new ConsoleUI();

            this.AppKernel.Bind<IInputReader>().ToMethod(ctx => consoleUi).InSingletonScope();
            this.AppKernel.Bind<IPrinter>().ToMethod(ctx => consoleUi).InSingletonScope();
        }
    }
}
