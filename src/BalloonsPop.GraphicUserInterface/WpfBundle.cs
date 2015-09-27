namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Common.Contracts;

    using BalloonsPop.Bundling;
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