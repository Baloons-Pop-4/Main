namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;
    using System.Text.RegularExpressions;

    public class UserInputValidator : IUserInputValidator
    {
        private const string ValidationPattern = "[0-4][^(a-z|0-9)][0-9]";
        private static readonly Regex validationRegex = new Regex(ValidationPattern, RegexOptions.IgnoreCase);

        private const int ValidInputLength = 3;
        private const int MaxRowInputValue = 4;

        public UserInputValidator()
        {
        }

        public bool IsValidUserMove(string userInput)
        {
            return HasCorrectLength(userInput) && IsValidCommand(userInput) && IsValidRowMove(userInput[0]);
        }

        private static bool HasCorrectLength(string input)
        {
            return input.Length == ValidInputLength;
        }

        private static bool IsValidCommand(string command)
        {
            return validationRegex.Match(command).Length > 0;
        }

        private static bool IsValidRowMove(char notParsedRow)
        {
            return (notParsedRow - 48) <= MaxRowInputValue;
        }
    }
}
