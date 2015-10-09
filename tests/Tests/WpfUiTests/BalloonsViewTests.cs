using System;
using BalloonsPop.GraphicUserInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.WpfUiTests
{
    [TestClass]
    public class BalloonsViewTests
    {
        private BalloonsView view;

        [TestInitialize]
        public void TestInit()
        {
            this.view = new BalloonsView();
        }

        [TestMethod]
        public void TestIfButtonDictionaryReturnsCorrectButtons()
        {
            string[] buttonsKeys = { BalloonsView.ExitButtonKey, BalloonsView.UndoButtonKey, BalloonsView.RestartButtonKey };

            foreach (var key in buttonsKeys)
            {
                Assert.IsTrue(this.view.CommandButtons.ContainsKey(key));
            }
        }

        [TestMethod]
        public void TestIfCommandButtonsPropertyReturnsTheSameButtonsAsTheButtonProperties()
        {
            string[] buttonsKeys = { BalloonsView.ExitButtonKey, BalloonsView.UndoButtonKey, BalloonsView.RestartButtonKey };


            bool correctRestartBtn = ReferenceEquals(this.view.CommandButtons[BalloonsView.RestartButtonKey], this.view.StartButton);
            bool correctUndoBtn = ReferenceEquals(this.view.CommandButtons[BalloonsView.UndoButtonKey], this.view.UndoButton);
            bool correctExitBtn = ReferenceEquals(this.view.CommandButtons[BalloonsView.ExitButtonKey], this.view.ExitButton);

            Assert.IsTrue(correctExitBtn && correctRestartBtn && correctUndoBtn);

        }

        [TestMethod]
        public void TestIfMessagePropertyReturnsTheSameValueItIsSetTo()
        {
            this.view.Message = "asd";
            Assert.AreEqual("asd", this.view.Message);
        }

        [TestMethod]
        public void TestIfUserMovesPropertyReturnsTheSameValueItIsSetTo()
        {
            this.view.UserMoves = "5353";
            Assert.AreEqual("5353", this.view.UserMoves);
        }
    }
}
