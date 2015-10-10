namespace Tests.WpfUiTests
{
    using System;
    using BalloonsPop.GraphicUserInterface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for MainWindowControllerTests
    /// </summary>
    [TestClass]
    public class MainWindowControllerTests
    {
        private BalloonsView view;
        private MainWindowController controller;
        private Resources resourceProvider;

        [TestInitialize]
        public void TestInit()
        {
            this.view = new BalloonsView();
            this.resourceProvider = new Resources();
            this.controller = new MainWindowController(this.view, this.resourceProvider);
        }

        [TestMethod]
        public void TestIfControllersRaisePropertyAddsMethodsFromBalloonsViewRaiseCommandEventHandler()
        {
            bool hasBeenCalled = false;
            this.controller.RaiseCommand += (s, e) => hasBeenCalled = true;
            this.view.Raise(this.view, new EventArgs());

            Assert.IsTrue(hasBeenCalled);
        }

        [TestMethod]
        public void TestIfControllerPropertyRaiseCommandRemovesMethodsFromViewsRaiseCommandEventHandler()
        {
            bool hasBeenCalled = false;
            EventHandler action = (s, e) => hasBeenCalled = true;
            this.controller.RaiseCommand += (s, e) => { };
            this.controller.RaiseCommand += action;
            this.controller.RaiseCommand -= action;
            this.view.Raise(this.view, new EventArgs());

            Assert.IsFalse(hasBeenCalled);
        }

        [TestMethod]
        public void TestIfPrintMessageSetsTheViewMessageProperty()
        {
            this.controller.PrintMessage("peshoq");
            Assert.AreEqual("peshoq", this.view.Message);
        }

        [TestMethod]
        public void TestIfTheWindowPropertyOfTheControllerReturnsTheSameViewItHasBeenPassedInConstructor()
        {
            Assert.AreSame(this.view, this.controller.Window);
        }
    }
}
