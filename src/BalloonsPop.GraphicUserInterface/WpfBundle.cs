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
        /// Initializes a new instance of the <see cref="WpfBundle" /> class through injection with the provided kernel.
        /// </summary>
        /// <param name="kernel"></param>
        public WpfBundle(IKernel kernel)
            : base(kernel)
        {
            kernel.Inject(this.Gui);
        }

        /// <summary>
        /// Gets or sets access to the graphic interface exported by the wpf project.
        /// </summary>
        [Inject]
        public IEventBasedUserInterface Gui { get; set; }
    }
}