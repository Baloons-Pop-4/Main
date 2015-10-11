namespace Tests.WpfUiTests
{
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
    using BalloonsPop.SoundPlayer;
    using BalloonsPop.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ninject;

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
            this.kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());
            DependancyBinder.Instance
                .RegisterModules(
                                 new ModelsModule(this.kernel),
                                 new LogicModule(this.kernel),
                                 new ValidationModule(this.kernel),
                                 new WpfCommandModule(this.kernel),
                                 new HighscoreModule(this.kernel),
                                 new SaverModule(this.kernel),
                                 new WpfModule(this.kernel),
                                 new SoundsModule(this.kernel))
                .LoadAll();

            this.bundle = new WpfBundle(this.kernel);
            this.ctx = new Context(this.kernel);
            this.engine = new EventEngine(this.ctx, this.bundle);
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
