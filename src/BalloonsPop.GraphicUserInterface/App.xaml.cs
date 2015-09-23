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

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private EngineCore engine;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var graphicUi = new MainWindow();
            var factory = new CommandFactory();
            var validator = MatrixValidator.GetInstance;
            var logicProvider = new LogicProvider(validator);
            var model = new GameModel(logicProvider.GenerateField());
            var table = new HighscoreTable();

            this.engine = new EventEngine(graphicUi, UserInputValidator.GetInstance, factory, model, logicProvider, table);

            graphicUi.Show();
        }
    }
}
