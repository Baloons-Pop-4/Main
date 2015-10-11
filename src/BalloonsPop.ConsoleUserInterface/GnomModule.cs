namespace BalloonsPop.ConsoleUserInterface
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// This class inherits the NinjectModule class and provides loading with a provided kernel for the exports of the gnom app.
    /// </summary>
    public class GnomModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GnomModule" /> class. It accepts a kernel which is used to bind exports.
        /// </summary>
        /// <param name="kernel">The kernel to which the AppKernel property will be set.</param>
        public GnomModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Returns the kernel which the instance of WpfModule will use to bind exports.
        /// </summary>
        public IKernel AppKernel { get; private set; }

        /// <summary>
        /// This overload of the method Load provides binding for the project exports.
        /// </summary>
        public override void Load()
        {
            this.AppKernel.Unbind<IPrinter>();
            this.AppKernel.Bind<IPrinter>().ToMethod(x => GnomViewProvider.GetController());
        }
    }
}