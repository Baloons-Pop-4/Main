namespace BalloonsPop.GraphicUserInterface
{
    using System.Windows;
    using BalloonsPop.Bundling;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Contexts;
    using BalloonsPop.GameModels;
    using BalloonsPop.GraphicUserInterface.Commands;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Saver;
    using BalloonsPop.SoundPlayer;
    using BalloonsPop.Validation;
    using Ninject;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EventEngine engine;

        /// <summary>
        /// This override sets up the balloons app.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var kernel = new StandardKernel();
            kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());
            DependancyBinder.Instance
                .RegisterModules(
                                 new ModelsModule(kernel),
                                 new LogicModule(kernel),
                                 new ValidationModule(kernel),
                                 new WpfCommandModule(kernel),
                                 new HighscoreModule(kernel),
                                 new SaverModule(kernel),
                                 new WpfModule(kernel),
                                 new SoundsModule(kernel))
                .LoadAll();       
    
            var bundle = new WpfBundle(kernel);
            var ctx = new Context(kernel);
            var engine = new EventEngine(ctx, bundle);

            this.engine = engine;

            bundle.Gui.Show();
        }
    }
}
