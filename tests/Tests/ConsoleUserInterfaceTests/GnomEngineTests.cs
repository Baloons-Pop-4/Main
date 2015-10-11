using System;
using BalloonsPop.Bundling;
using BalloonsPop.Common.Contracts;
using BalloonsPop.Common.Gadgets;
using BalloonsPop.ConsoleUserInterface;
using BalloonsPop.Core.Commands;
using BalloonsPop.Core.Contexts;
using BalloonsPop.GameModels;
using BalloonsPop.Highscore;
using BalloonsPop.LogicProvider;
using BalloonsPop.Saver;
using BalloonsPop.SoundPlayer;
using BalloonsPop.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Tests.ConsoleUserInterfaceTests
{
    [TestClass]
    public class GnomEngineTests
    {
        private GnomEngine engine;
        private IContext context;

        [TestInitialize]
        public void TestInit()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());

            DependancyBinder.Instance
                .RegisterModules(
                                 new ModelsModule(kernel),
                                 new LogicModule(kernel),
                                 new ValidationModule(kernel),
                                 new HighscoreModule(kernel),
                                 new SaverModule(kernel),
                                 new SoundsModule(kernel),
                                 new CommandModule(kernel),
                                 new GnomModule(kernel))
                .LoadAll();

            var bundle = new CoreBundle(kernel);
            this.context = new Context(kernel);

            this.engine = new GnomEngine(this.context, bundle);

        }

        [TestCleanup]
        public void CleanUp()
        {
            DependancyBinder.Instance.Modules.Clear();
        }

        [TestMethod]
        public void TestIfEngineDoesntThrowExceptionsWithValidInput()
        {
            string[] validInput = { "field", "1 1", "top", "gameover"};

            foreach (var input in validInput)
            {
                this.engine.HandleUserInput(input);
            }
        }

        [TestMethod]
        public void TestIfPopCommandPopsBalloonAtTheSpecifiedSpot()
        {
            this.engine.HandleUserInput("1 1");
            Assert.IsTrue(this.context.Game.Field[1, 1].IsPopped);
        }
    }
}
