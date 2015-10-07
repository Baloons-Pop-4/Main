namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Bundling;
    using BalloonsPop.GraphicUserInterface.Contracts;
    using Ninject;

    public class WpfBundle : CoreBundle
    {
        public WpfBundle(IKernel kernel)
            : base(kernel)
        {
            kernel.Inject(this.Gui);
        }

        [Inject]
        public IEventBasedUserInterface Gui { get; set; }
    }
}