namespace Tests.WpfUiTests
{
    using System;
    using BalloonsPop.GraphicUserInterface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserCommandArgsTests
    {
        [TestMethod]
        public void TestIfArgsReturnTheSameValueTheyWereCreateWith()
        {
            var content = "pingvin";
            var args = new UserCommandArgs(content);

            Assert.AreEqual(content, args.CommandToPass);
        }
    }
}
