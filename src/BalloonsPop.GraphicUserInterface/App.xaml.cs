using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Bundling;
    using BalloonsPop.Validation;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.GameModels;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Highscore;
    using Ninject;

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
                                 new CommandModule(kernel),
                                 new HighscoreModule(kernel),
                                 new WpfModule(kernel)
                                 )
                .LoadAll();            

            var bundle = new WpfBundle(kernel);
            var engine = new EventEngine(bundle);



            // this.engine = new EventEngine(graphicUi, new UserInputValidator(), factory, model, logicProvider, table, kernel.Get<IHighscoreSaver>());
            
            this.engine = engine;

            bundle.Gui.Show();
        }
    }
}
