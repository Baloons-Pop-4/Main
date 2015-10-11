namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.ConsoleUI.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class ConsoleModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleModule" /> class.
        /// </summary>
        /// <param name="kernel"></param>
        public ConsoleModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Gets or sets an AppKernel
        /// </summary>
        public IKernel AppKernel { get; set; } 

        public override void Load()
        {
            var consoleUi = new ConsoleUI();

            this.AppKernel.Bind<IInputReader>().ToMethod(ctx => consoleUi).InSingletonScope();
            this.AppKernel.Bind<IPrinter>().ToMethod(ctx => consoleUi).InSingletonScope();
        }
    }
}
