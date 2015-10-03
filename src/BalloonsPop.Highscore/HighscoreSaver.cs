namespace BalloonsPop.Highscore
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    using Ninject;

    public sealed class HighscoreSaver : IHighscoreSaver
    {
        private static readonly Lazy<HighscoreSaver> Instance =
            new Lazy<HighscoreSaver>(
                () => new HighscoreSaver(new XmlFileSavingStrategy()));

        private IHighscoreSavingStrategy highscoreSavingStrategy;

        private HighscoreSaver(IHighscoreSavingStrategy highscoreSavingStrategy)
        {
            this.highscoreSavingStrategy = highscoreSavingStrategy;
        }

        public static HighscoreSaver GetInstance(IKernel kernelForInjection)
        {
            if (Instance.IsValueCreated == false)
            {
                kernelForInjection.Inject(Instance.Value);
            }

            return Instance.Value;
        }

        public void Save(List<IPlayerScore> highscoreTable)
        {
            this.highscoreSavingStrategy.Save(highscoreTable);
        }
    }
}
