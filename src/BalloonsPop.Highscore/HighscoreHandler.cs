// <copyright file="HighscoreHandler.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Highscore.HighscoreHandlingStrategies;

    using Ninject;

    /// <summary>
    /// This singleton class delegates the saving/loading of high score tables to an appropriate handling strategy.
    /// </summary>
    public sealed class HighscoreHandler : IHighscoreHandler
    {
        /// <summary>
        /// Holds the handler instance and utilizes the Lazy class.
        /// </summary>
        private static readonly Lazy<HighscoreHandler> Instance =
            new Lazy<HighscoreHandler>(
                () => new HighscoreHandler(new XmlHandlingStrategy()));

        /// <summary>
        /// The handling strategy to be used.
        /// </summary>
        private readonly IHighscoreHandlingStrategy highscoreHandlingStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreHandler"/> class.
        /// </summary>
        /// <param name="highscoreHandlingStrategy">The concrete strategy to be used for handling the high score table.</param>
        private HighscoreHandler(IHighscoreHandlingStrategy highscoreHandlingStrategy)
        {
            this.highscoreHandlingStrategy = highscoreHandlingStrategy;
        }

        /// <summary>
        /// Retrieves the current class instance.
        /// </summary>
        /// <param name="kernelForInjection">The kernel to be injected to. Ensures the class is lazily instantiated.</param>
        /// <returns>An instance of the <see cref="HighscoreHandler"/> class.</returns>
        public static HighscoreHandler GetInstance(IKernel kernelForInjection)
        {
            if (Instance.IsValueCreated == false)
            {
                kernelForInjection.Inject(Instance.Value);
            }

            return Instance.Value;
        }

        /// <summary>
        /// Delegates the saving of a <see cref="IHighscoreTable"/> to a previously set <see cref="IHighscoreHandlingStrategy"/>.
        /// </summary>
        /// <param name="highscoreTable">The <see cref="IHighscoreTable"/> to be saved.</param>
        public void Save(IHighscoreTable highscoreTable)
        {
            this.highscoreHandlingStrategy.Save(highscoreTable);
        }

        /// <summary>
        /// Delegates the loading of a <see cref="IHighscoreTable"/> to a previously set <see cref="IHighscoreHandlingStrategy"/>.
        /// </summary>
        /// <returns>The retrieved <see cref="IHighscoreTable"/>.</returns>
        public IHighscoreTable Load()
        {
            return this.highscoreHandlingStrategy.Load();
        }
    }
}
