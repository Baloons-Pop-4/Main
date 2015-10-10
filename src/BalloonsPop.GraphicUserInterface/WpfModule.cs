namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GraphicUserInterface.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// This class inherits the NinjectModule class and provides loading with a provided kernel for the exports of the wpf project.
    /// </summary>
    public class WpfModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WpfModule" /> class. It accepts a kernel which is used to bind exports.
        /// </summary>
        /// <param name="kernel">The kernel to which the AppKernel property will be set.</param>
        public WpfModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Gets or sets the kernel which the instance of WpfModule will use to bind exports.
        /// </summary>
        public IKernel AppKernel { get; set; }

        /// <summary>
        /// This overload of the method Load provides binding for the project exports.
        /// </summary>
        public override void Load()
        {
            var window = new BalloonsView();
            var controller = new MainWindowController(window, new Resources());

            this.AppKernel.Bind<IEventBasedUserInterface>().ToMethod(ctx => controller);
            this.AppKernel.Bind<IPrinter>().ToMethod(ctx => controller);
        }
    }
}