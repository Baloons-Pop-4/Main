namespace BalloonsPop.SoundPlayer
{
    using BalloonsPop.Common.Contracts;
    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Provides binding for the exports of the SoundPlayer project on the provided kernel.
    /// </summary>
    public class SoundsModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoundsModule" /> class.
        /// </summary>
        /// <param name="kernel"></param>
        public SoundsModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Gets the kernel on which the exports are bound.
        /// </summary>
        public IKernel AppKernel { get; private set; }

        /// <summary>
        /// Binds the exports to the module kernel.
        /// </summary>
        public override void Load()
        {
            this.AppKernel.Unbind<ISoundsPlayer>();
            this.AppKernel.Bind<ISoundsPlayer>().ToMethod(x => new SoundsPlayer(new SoundsLoader())).InSingletonScope();
        }
    }
}
