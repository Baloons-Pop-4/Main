namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Linq;
    using System.Windows;
    using BalloonsPop.Bundling;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Saver;
    using BalloonsPop.GameModels;
    using BalloonsPop.GraphicUserInterface.Commands;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Validation;
    using Ninject;
    using BalloonsPop.Core.Contexts;
    using BalloonsPop.Highscore.HighscoreHandlingStrategies;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EventEngine engine;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var kernel = new StandardKernel();

            DependancyBinder.Instance
                .RegisterModules(
                                 new ModelsModule(kernel),
                                 new LogicModule(kernel),
                                 new ValidationModule(kernel),
                                 new WpfCommandModule(kernel),
                                 new HighscoreModule(kernel),
                                 new SaverModule(kernel),
                                 new WpfModule(kernel))
                .LoadAll();            

            var bundle = new WpfBundle(kernel);
            var ctx = new Context(kernel);
            var engine = new EventEngine(ctx, bundle);

            this.engine = engine;

            bundle.Gui.Show();
        }
    }
}
