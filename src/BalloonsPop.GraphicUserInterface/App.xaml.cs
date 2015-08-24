using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BalloonsPop.GraphicUserInterface
{
<<<<<<< HEAD:src/BaloonsPop.GraphicUserInterface/App.xaml.cs
    using BaloonsPop.Common.Contracts;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using BaloonsPop.Engine.Commands;
    using BaloonsPop.Common;
=======
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Validators;
    using BalloonsPop.Engine;
    using BalloonsPop.Engine.Commands;
>>>>>>> master:src/BalloonsPop.GraphicUserInterface/App.xaml.cs

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
