using System;
using System.Windows.Controls;
using BalloonsPop.Bundling;
using BalloonsPop.Common.Contracts;
using BalloonsPop.Common.Gadgets;
using BalloonsPop.Core.Contexts;
using BalloonsPop.GameModels;
using BalloonsPop.GraphicUserInterface;
using BalloonsPop.GraphicUserInterface.Commands;
using BalloonsPop.GraphicUserInterface.Contracts;
using BalloonsPop.Highscore;
using BalloonsPop.LogicProvider;
using BalloonsPop.Saver;
using BalloonsPop.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace Tests.WpfUiTests
{
    [TestClass]
    public class EventEngineTests
    {
        private MainWindowController controller;
        private EventEngine engine;
        private BalloonsView view;
        private IContext ctx;
        private IBalloonsWpfResourceProvider resources;
        private IKernel kernel;
        private WpfBundle bundle;

        public EventEngineTests()
        {
            this.kernel = new StandardKernel();
            kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());
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
            
            this.bundle = new WpfBundle(this.kernel);
            this.ctx = new Context(kernel);
            this.engine = new EventEngine(ctx, bundle);
            this.view = new BalloonsView();
            this.resources = new Resources();
            this.controller = new MainWindowController(this.view, this.resources);
        }

        [TestMethod]
        public void TestIfSetPlayerNameInContextSetsTheNewNameInContext()
        {
            this.engine.SetPlayerNameInContext(new TextBox() { Text = "gosho" }, new EventArgs());

            Assert.AreEqual("gosho", this.ctx.PlayerName);
        }

        [TestMethod]
        public void TestIfEventEngineDoesntThrowExceptionDoesntThrowExceptionsWithValidCommands()
        {
             string[] validCommands = { "1 1", "undo", "2 2", "restart", "4 9", "3 3", "2 5", "undo", "undo", "9 9" };

            foreach (var cmd in validCommands)
            {
                this.engine.HandleUserInput(new object(), new UserCommandArgs(cmd));
            }
        }

        [TestMethod]
        public void TestIfInvalidCommandsPassedToTheEngineDoesntCrashIt()
        {
            this.engine.HandleUserInput(new object(), new UserCommandArgs("icrasheduzz"));
        }
    }
}
