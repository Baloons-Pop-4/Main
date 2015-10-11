namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class CommandModule : NinjectModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandModule" /> class.
        /// </summary>
        /// <param name="kernel"></param>
        public CommandModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        /// <summary>
        /// Gets or sets an AppKernel
        /// </summary>
        public IKernel AppKernel { get; set; } 

        public override void Load()
        {
            this.AppKernel.Bind<ICommandFactory>().To<CommandFactory>();
        }
    }
}