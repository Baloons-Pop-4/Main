namespace Tests.WpfUiTests.ExtensionsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows.Controls;

    using BalloonsPop.GraphicUserInterface.Gadgets;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfWrapInTextBlockThrowsAnExceptionIfStringIsNull()
        {
            var box = new TextBlock();
            string nullString = null;

            nullString.WrapInTextBox(box);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfWrapInTextBlockThrowsAnExceptionIfTextBlockIsNull()
        {
            TextBlock box = null;
            string gosho = "gosho";

            gosho.WrapInTextBox(box);
        }

        [TestMethod]
        public void TestIfWrapInTextBlockReturnATextBlockWithTheStringAsContent()
        {
            TextBlock box = new TextBlock();
            string gosho = "gosho";

            gosho.WrapInTextBox(box);

            Assert.AreEqual(gosho, box.Text);
        }
    }
}
