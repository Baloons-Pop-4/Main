namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPop.Validation;

    [TestClass]
    public class MatrixValidatorTests
    {
        private MatrixValidator validator = new MatrixValidator();

        [TestMethod]
        public void TestIfIsInsideMethodReturnsFalseForTooSmallRow()
        {
            Assert.IsFalse(validator.IsInsideMatrix(new byte[2, 5], -1, 2));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooLargeRow()
        {
            Assert.IsFalse(validator.IsInsideMatrix(new byte[2, 5], 2, 2));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooSmallCol()
        {
            Assert.IsFalse(validator.IsInsideMatrix(new byte[2, 5], 2, -1));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooLargeCol()
        {
            Assert.IsFalse(validator.IsInsideMatrix(new byte[2, 5], 0, 5));
        }
    }
}