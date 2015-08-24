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
    using BaloonsPop.Common;

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
            var rng = new RandomNumberGenerator();
            var logicProvider = new GameLogic(validator, rng);
            var field = new BaloonField();
            var model = new Game(field);

            this.engine = new GraphicEngine(graphicUi, UserInputValidator.GetInstance, factory, model, logicProvider);

            graphicUi.Show();
        }
    }
}
