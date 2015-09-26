namespace BalloonsPop.Highscore
{
    using System;
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;
    using Ninject;

    public sealed class HighscoreSaver : IHighscoreSaver
    {
        private static readonly Lazy<HighscoreSaver> instance =
            new Lazy<HighscoreSaver>(
                () => new HighscoreSaver(new XmlFileSavingStrategy()));

        private IHighscoreSavingStrategy highscoreSavingStrategy;

        private HighscoreSaver(IHighscoreSavingStrategy highscoreSavingStrategy)
        {
            this.highscoreSavingStrategy = highscoreSavingStrategy;
        }

        public static HighscoreSaver GetInstance(IKernel kernelForInjection)
        {
            if (instance.IsValueCreated == false)
            {
                kernelForInjection.Inject(instance.Value);
            }

            return instance.Value;
        }

        public void Save(List<IPlayerScore> highscoreTable)
        {
            highscoreSavingStrategy.Save(highscoreTable);
        }
    }
}
