namespace BalloonsPop.Common.Validators
{
    using BalloonsPop.Common.Contracts;

    public class UserInputValidator : IUserInputValidator
    {
        private const char Comma = ',';
        private const char Dot = '.';
        private const int ValidInputLength = 3;
        private const int MaxRowInputValue = 4;

        public UserInputValidator()
        {
        }

        public bool IsValidUserMove(string userInput)
        {
            bool hasCorrectLength = userInput.Length == ValidInputLength;

            if (!hasCorrectLength)
            {
                return false;
            }

            bool firstCharIsDigit = char.IsDigit(userInput[2]);
            bool secondCharIsValid = char.IsWhiteSpace(userInput[1]) || userInput[1] == Dot || userInput[1] == Comma;
            bool thirdCharIsDigit = char.IsDigit(userInput[2]);

            return firstCharIsDigit && secondCharIsValid && thirdCharIsDigit && this.IsValidRowMove(userInput[0]);
        }

        private bool IsValidRowMove(char notParsedRow)
        {
            bool isValidRow = (notParsedRow - 48) <= MaxRowInputValue;
            return isValidRow;
        }
    }
}
