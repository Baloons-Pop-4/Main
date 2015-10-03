namespace Tests
{
    using System;

    using BalloonsPop.Validation;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixValidatorTests
    {
        private MatrixValidator validator = new MatrixValidator();

        [TestMethod]
        public void TestIfIsInsideMethodReturnsFalseForTooSmallRow()
        {
            Assert.IsFalse(this.validator.IsInsideMatrix(new byte[2, 5], -1, 2));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooLargeRow()
        {
            Assert.IsFalse(this.validator.IsInsideMatrix(new byte[2, 5], 2, 2));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooSmallCol()
        {
            Assert.IsFalse(this.validator.IsInsideMatrix(new byte[2, 5], 2, -1));
        }

        [TestMethod]
        public void TestIfInsideMethodReturnsFalseForTooLargeCol()
        {
            Assert.IsFalse(this.validator.IsInsideMatrix(new byte[2, 5], 0, 5));
        }
    }
}