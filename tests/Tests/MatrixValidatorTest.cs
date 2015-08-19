namespace Tests
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixValidatorTests
    {
        private MatrixValidator validator = MatrixValidator.GetInstance;

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