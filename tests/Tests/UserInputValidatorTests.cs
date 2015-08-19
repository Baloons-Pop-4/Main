namespace Tests
{
    using System;
    using BaloonsPop.Common.Validators;
    using BaloonsPop.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserInputValidatorTests
    {
        private UserInputValidator validator = UserInputValidator.GetInstance;

        [TestMethod]
        public void TestIfIsValidUserMoveReturnsTrueForValidMoves()
        {
            var validMoves = new string[] { "1 1", "0.0", "0,1", "0 0", "4 9"};

            foreach (var move in validMoves)
            {
                Assert.IsTrue(this.validator.IsValidUserMove(move));
            }
        }

        [TestMethod]
        public void TestIfIValidUserMoveReturnsFalseForInputWithInvalidLength()
        {
            var movesWithInvalidLength = new string[] { "1  1", "10 1", "1 10", "2,,2", "", "1", "11", ".."};

            foreach (var move in movesWithInvalidLength)
            {
                Assert.IsFalse(this.validator.IsValidUserMove(move));
            }
        }

        [TestMethod]
        public void TestIfIsValidUserMoveReturnsFalseForMovesWithInvalidContent()
        {
            var movesWithInvalidContent = new string[] { "101", ".1.", "999", "aaa", "---", "1-1"};

            foreach (var move in movesWithInvalidContent)
            {
                Assert.IsFalse(this.validator.IsValidUserMove(move));
            }
        }

        [TestMethod]
        public void TestIfIsValidUserMoveReturnsFaleForMovesWithTooBigValues()
        {
            var movesWithTooBigValue = new string[] { "5,6", "5 10", "8, 2", "9,0", "6.3" };

            foreach (var move in movesWithTooBigValue)
            {
                Assert.IsFalse(this.validator.IsValidUserMove(move));
            }
        }
    }
}