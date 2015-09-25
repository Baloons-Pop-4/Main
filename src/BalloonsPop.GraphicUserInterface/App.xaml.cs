using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Core;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.GraphicUserInterface;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EngineCore engine;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var kernel = new StandardKernel();

            kernel.Bind<IEventBasedUserInterface>().To<MainWindow>();
            kernel.Bind<ICommandFactory>().To<CommandFactory>();
            kernel.Bind<IMatrixValidator>().To<MatrixValidator>();
            kernel.Bind<IGameLogicProvider>().To<LogicProvider>();
            kernel.Bind<IHighscoreTable>().To<HighscoreTable>();
            
            

            //var graphicUi = new MainWindow();
            var graphicUi = kernel.Get<IEventBasedUserInterface>();
            var factory = kernel.Get<ICommandFactory>();
            var validator = kernel.Get<IMatrixValidator>();
            var logicProvider = kernel.Get<IGameLogicProvider>();
            var model = new GameModel(logicProvider.GenerateField());
            var table = kernel.Get<IHighscoreTable>();

            this.engine = new EventEngine(graphicUi, new UserInputValidator(), factory, model, logicProvider, table);

            graphicUi.Show();
        }
    }
}
