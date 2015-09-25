namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    public class UserInputValidator : IUserInputValidator
    {
        private const char COMMA = ',';
        private const char DOT = '.';
        private const int VALID_INPUT_LENGTH = 3;
        private const int MAX_ROW_INPUT_VALUE = 4;

        public UserInputValidator()
        {
        }

        public bool IsValidUserMove(string userInput)
        {
            bool hasCorrectLength = userInput.Length == VALID_INPUT_LENGTH;

            if (!hasCorrectLength)
            {
                return false;
            }

            bool firstCharIsDigit = char.IsDigit(userInput[2]);
            bool secondCharIsValid = char.IsWhiteSpace(userInput[1]) || userInput[1] == DOT || userInput[1] == COMMA;
            bool thirdCharIsDigit = char.IsDigit(userInput[2]);

            return firstCharIsDigit && secondCharIsValid && thirdCharIsDigit && this.IsValidRowMove(userInput[0]);
        }

        private bool IsValidRowMove(char notParsedRow)
        {
            bool isValidRow = (notParsedRow - 48) <= MAX_ROW_INPUT_VALUE;
            return isValidRow;
        }
    }
}
