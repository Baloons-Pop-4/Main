namespace BalloonsPop.GraphicUserInterface.Commands
{
    using System;
using BalloonsPop.Common.Contracts;
using BalloonsPop.Core.Commands;
using Ninject;

    /// <summary>
    /// Extends the core CommandModule and exports a module consisting of core commands and additional commands defined by the wpf application.
    /// </summary>
    public class WpfCommandModule : CommandModule
    {
        private const string WpfExitCommandKey = "exit";

        private static readonly Func<ICommand> WpfProviderMethod = () => new WpfExitCommand();

        /// <summary>
        /// Public contructor that sets this modules kernel.
        /// </summary>
        /// <param name="kernel">The kernel which the current instance of the module will use for binding.</param>
        public WpfCommandModule(IKernel kernel)
            : base(kernel)
        {
        }

        /// <summary>
        /// Provides loading for the wpf module exports.
        /// </summary>
        public override void Load()
        {
            this.AppKernel.Bind<ICommandFactory>().ToMethod(x =>
            {
                var newCmdFactory = new CommandFactory();

                newCmdFactory.UnregisterCommand(WpfExitCommandKey);
                newCmdFactory.RegisterCommand(WpfExitCommandKey, WpfProviderMethod);

                return newCmdFactory;
            });
        }
    }
}
