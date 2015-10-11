using System;
using System.Windows.Controls;
using BalloonsPop.Bundling;
using BalloonsPop.Common.Contracts;
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

        [TestInitialize]
        public void TestInit()
        {
            this.view = new BalloonsView();
            this.resources = new Resources();
            this.controller = new MainWindowController(this.view, this.resources);
        }

        [TestMethod]
        public void TestIfSetPlayerNameInContextSetsTheNewNameInContext()
        {
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
            this.ctx = new Context(kernel);
            var engine = new EventEngine(ctx, bundle);

            this.engine = engine;

            this.engine.SetPlayerNameInContext(new TextBox() { Text = "gosho" }, new EventArgs());

            Assert.AreEqual("gosho", this.ctx.PlayerName);
        }
    }
}
