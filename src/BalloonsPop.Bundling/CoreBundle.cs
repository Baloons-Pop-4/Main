namespace BalloonsPop.Bundling
{
    using BalloonsPop.Common.Contracts;

    using Ninject;

    /// <summary>
    /// Provides IoC container for EngineCore dependencies. Injected with ninject.
    /// </summary>
    public class CoreBundle : ICoreBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreBundle" /> class through injection with the provided kernel.
        /// </summary>
        /// <param name="kernel"></param>
        public CoreBundle(IKernel kernel)
        {
            kernel.Inject(this);
        }

        [Inject]
        public IUserInputValidator UserInputValidator { get; set; }

        [Inject]
        public ICommandFactory CommandFactory { get; set; }

        [Inject]
        public ILogger Logger { get; set; }
    }
}