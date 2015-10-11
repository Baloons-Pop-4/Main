

namespace Tests.ModulesAndBindingTests
{
    using System;
    using BalloonsPop.GameModels;
    using BalloonsPop.GraphicUserInterface;
    using BalloonsPop.Saver;
    using BalloonsPop.Validation;
    using BalloonsPop.Common.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.GraphicUserInterface.Commands;
    using BalloonsPop.GraphicUserInterface.Contracts;

    [TestClass]
    public class ModuleTests
    {
        private IKernel kernel;

        public ModuleTests()
        {
            this.kernel = new StandardKernel();
        }

        [TestMethod]
        public void TestIfValidationModuleBindsValidatorsToInterfaces()
        {
            new ValidationModule(this.kernel).Load();

            var matrixValidator = kernel.Get<IMatrixValidator>();

            Assert.IsNotNull(matrixValidator);

            Assert.IsNotNull(kernel.Get<IUserInputValidator>());
        }

        [TestMethod]
        public void TestIfStateSaverModuleBindsToIStateSaverWithIGameModelType()
        {
            new SaverModule(this.kernel).Load();

            var memento = this.kernel.Get<IStateSaver<IGameModel>>();

            Assert.AreEqual(typeof(Saver<IGameModel>), memento.GetType());
        }

        [TestMethod]
        public void TestIfLogicProviderModuleBindsItsModulesToTheRespectiveInterfacesFromCommonProject()
        {
            new ValidationModule(this.kernel).Load();
            new LogicModule(this.kernel).Load();

            var logicProvider = this.kernel.Get<IGameLogicProvider>();

            Assert.AreEqual(typeof(LogicProvider), logicProvider.GetType());
        }

        [TestMethod]
        public void TestIfModelsModuleLoadsTheCorrectTypesFromTheProject()
        {
            new ModelsModule(this.kernel).Load();

            Assert.AreEqual(typeof(GameModel), this.kernel.Get<IGameModel>().GetType());
            Assert.AreEqual(typeof(Balloon), this.kernel.Get<IBalloon>().GetType());
        }

        [TestMethod]
        public void TestIfWpfCommandModuleBindsExitCommandToWpfExitCommand()
        {
            new WpfCommandModule(this.kernel).Load();

            var cmdFactory = this.kernel.Get<ICommandFactory>();

            Assert.AreEqual(typeof(WpfExitCommand), cmdFactory.CreateCommand("exit").GetType());
        }

        [TestMethod]
        public void TestIfWpfModuleBindsInterfacesToItsExports()
        {
            new WpfModule(this.kernel).Load();

            Assert.AreEqual(typeof(MainWindowController), this.kernel.Get<IEventBasedUserInterface>().GetType());
        }
    }
}
