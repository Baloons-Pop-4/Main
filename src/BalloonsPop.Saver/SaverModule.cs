namespace BalloonsPop.Saver
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// This class inherits the NinjectModule class and provides loading with a provided kernel for the exports of the saver project.
    /// </summary>
    public class SaverModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaverModule" /> class which accepts a kernel that it later uses to bind exports.
        /// </summary>
        /// <param name="kernel">The kernel to which the AppKernel property will be set.</param>
        public SaverModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Gets or sets the kernel which the instance of SaveModule will use to bind exports.
        /// </summary>
        public IKernel AppKernel { get; set; }

        /// <summary>
        /// This overload of the method Load provides binding for the project exports.
        /// </summary>
        public override void Load()
        {
            this.AppKernel.Unbind<IStateSaver<IGameModel>>();
            this.AppKernel.Bind<IStateSaver<IGameModel>>().To<Saver<IGameModel>>();
        }
    }
}