namespace Tests.WpfUiTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.GameModels;
    using BalloonsPop.GraphicUserInterface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Highscore;
    using Moq;

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

        [TestMethod]
        public void TestIfPrintFieldInitializesTheImageSourcesAtFirstPrint()
        {

            var game = new GameModel();
            Assert.AreEqual(0, this.view.BalloonGrid.Children.Count);
            this.controller.PrintField(game.Field);
            Assert.AreEqual(50, this.view.BalloonGrid.Children.Count);
        }

        [TestMethod]
        public void TestIfPrintFieldChangesTheSourceOfTheImages()
        {

            var game = new GameModel();
            Assert.AreEqual(0, this.view.BalloonGrid.Children.Count);

            this.controller.PrintField(game.Field);
            var sources = this.view.BalloonGrid.Children.Cast<Image>().Select(x => x.Source).ToList();
            var redField = new QueryableMatrix<IBalloon>(5, 10).Select(x => new Balloon() { Number = 1 }).ToMatrix(5, 10);

            this.controller.PrintField(redField);
            var sources2 = this.view.BalloonGrid.Children.Cast<Image>().Select(x => x.Source).ToList();

            bool different = false;
            for (int i = 0; i < sources.Count; i++)
            {
                different = sources[i].ToString() != sources2[i].ToString();
            }

            Assert.IsTrue(different);
        }

        [TestMethod]
        public void TestIfPrintPlayerMovesDisplaysThePassedValue()
        {
            this.controller.PrintPlayerMoves("9");
            Assert.AreEqual("9", this.view.UserMoves);
        }

        [TestMethod]
        public void TestIfPrintHighscorePrintTheTableInCorrectFormat()
        {
            var now = DateTime.Now;
            var bivanScore = new PlayerScore("bay ivan", 10, now);
            var goshoScore = new PlayerScore("goshoto", 9, now);
            var mariaScore = new PlayerScore("mariya", 11, now);

            var tableToPrint = new HighscoreTable(new List<PlayerScore>() { bivanScore, goshoScore, mariaScore });

            this.controller.PrintHighscore(tableToPrint);

            var highscoreChildren = this.view.Rankings.Children.Cast<Border>().Select(x =>
                {
                    return (x.Child as TextBlock).Text;
                }).ToList();
        }

        [TestMethod]
        public void TestIfControllersTextChangedHandlerRemovesMethodsFromView()
        {
            bool firstCalled = false;
            bool secondCalled = false;
            TextChangedEventHandler action1 = (s, e) => { firstCalled = true; };
            TextChangedEventHandler action2 = (s, e) => { secondCalled = true; };
            this.controller.ChangedUserName += action1;
            this.controller.ChangedUserName += action2;

            this.view.PlayerNicknameBox.Text = "gosho";

            Assert.IsTrue(firstCalled && secondCalled);

            secondCalled = false;
            this.controller.ChangedUserName -= action2;

            this.view.PlayerNicknameBox.Text = "tosho";

            Assert.IsFalse(secondCalled);
        }

        [TestMethod]
        public void TestIfChangedPlayerNamePropertyAllowsAdditionOfMethodsToThePlayerNameTextBoxOfTheView()
        {
            bool called = false;
            this.controller.ChangedUserName += (s, e) => { called = true; };
            this.view.PlayerNicknameBox.Text = "boil";
            Assert.IsTrue(called);
        }
    }
}
