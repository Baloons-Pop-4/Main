namespace Tests.Gadget_tests
{
    using System;

    using BalloonsPop.Common.Gadgets;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "A string could not be parsed to Int32.")]
        public void ParsingWordsShouldThrowArgumentException()
        {
            int result = StringExtensions.ToInt32("Thirty one");
        }

        [TestMethod]
        public void ParsingStringNumberToInt32ShouldWorkCorrectly()
        {
            int result = StringExtensions.ToInt32("31");
            int expectedResult = 31;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "A char could not be parsed to Int32")]
        public void ParsingLetterShouldThrowArgumentException()
        {
            int result = StringExtensions.ToInt32('a');
        }

        [TestMethod]
        public void ParsingDigitToInt32ShouldWorkCorrectly()
        {
            int result = StringExtensions.ToInt32('3');
            int expectedResult = 3;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
