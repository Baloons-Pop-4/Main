namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Bundling;
    using BalloonsPop.GraphicUserInterface.Contracts;

    using Ninject;

    /// <summary>
    /// A class that inherits CoreBundle and is initialized with injection via ninject and wraps the exports of the wpf project.
    /// </summary>
    public class WpfBundle : CoreBundle
    {
        /// <summary>
        /// A constructor that uses a provided kernel to initialize the created instance.
        /// </summary>
        /// <param name="kernel"></param>
        public WpfBundle(IKernel kernel)
            : base(kernel)
        {
            kernel.Inject(this.Gui);
        }

        /// <summary>
        /// Provides access to the graphic interface exported by the wpf project.
        /// </summary>
        [Inject]
        public IEventBasedUserInterface Gui { get; set; }
    }
}