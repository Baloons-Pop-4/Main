namespace BalloonsPop.Core.Commands
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    public class CommandModule : NinjectModule
    {
        public IKernel AppKernel { get; set; } 

        public CommandModule(IKernel kernel)
        {
            this.AppKernel = kernel;
        }

        public override void Load()
        {
            this.AppKernel.Bind<ICommandFactory>().To<CommandFactory>();
        }
    }
}