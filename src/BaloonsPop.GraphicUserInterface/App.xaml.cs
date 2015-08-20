using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BaloonsPop.GraphicUserInterface
{
    using BaloonsPop.Common.Contracts;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Engine.Commands;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Engine engine;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var graphicUi = new MainWindow();
            var factory = new CommandFactory();
            var validator = MatrixValidator.GetInstance;
            var logicProvider = new GameLogic(validator);
            var model = new Game(logicProvider);

            this.engine = new GraphicEngine(graphicUi, UserInputValidator.GetInstance, factory, model, logicProvider);

            graphicUi.Show();
        }
    }
}
