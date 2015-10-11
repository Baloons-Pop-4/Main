// <copyright file="HighscoreModule.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Highscore.HighscoreHandlingStrategies;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// A <see cref="Ninject"/> module to load high score
    /// </summary>
    public class HighscoreModule : NinjectModule
    {
        /// <summary>
        /// Holds an instance to a <see cref="IKernel"/>.
        /// </summary>
        private static IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreModule"/> class.
        /// </summary>
        /// <param name="bindingKernel">The kernel to be used for binding.</param>
        public HighscoreModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        /// <summary>
        /// Binds the concrete instances to the kernel.
        /// </summary>
        public override void Load()
        {
            kernel.Unbind<IHighscoreHandlingStrategy>();
            kernel.Unbind<IHighscoreTable>();
            kernel.Bind<IHighscoreHandlingStrategy>().To<XmlHandlingStrategy>().WithConstructorArgument("highscore.xml");
            kernel.Bind<IHighscoreTable>().ToMethod(x => kernel.Get<IHighscoreHandlingStrategy>().Load());
        }
    }
}
