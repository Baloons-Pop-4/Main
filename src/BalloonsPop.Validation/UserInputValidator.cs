namespace BalloonsPop.Validation
{
    using System.Text.RegularExpressions;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Concrete implementation of the IUserInputValidator interface, using regular expression.
    /// </summary>
    public class UserInputValidator : IUserInputValidator
    {
        private const string ValidationPattern = "[0-4][^(a-z|0-9)][0-9]";
        private const int ValidInputLength = 3;
        private const int MaxRowInputValue = 4;

        private static readonly Regex ValidationRegex = new Regex(ValidationPattern, RegexOptions.IgnoreCase);

        /// <summary>
        /// Returns true when the provided string is a valid player move.
        /// </summary>
        /// <param name="playerMove">The player move as string.</param>
        /// <returns></returns>
        public bool IsValidUserMove(string playerMove)
        {
            return HasCorrectLength(playerMove) && IsValidCommand(playerMove) && IsValidRowMove(playerMove[0]);
        }

        /// <summary>
        /// Returns true if the player move has the appropriate length.
        /// </summary>
        /// <param name="playerMove">The player move as string.</param>
        /// <returns></returns>
        private static bool HasCorrectLength(string playerMove)
        {
            return playerMove.Length == ValidInputLength;
        }

        /// <summary>
        /// Returns true if the player move matches the specified pattern.
        /// </summary>
        /// <param name="playerMove">The player move as string.</param>
        /// <returns></returns>
        private static bool IsValidCommand(string playerMove)
        {
            return ValidationRegex.Match(playerMove).Length > 0;
        }

        /// <summary>
        /// Returns true if the row coordinate of the player move falls within the allowed range.
        /// </summary>
        /// <param name="playerMove">The player move as string.</param>
        /// <returns></returns>
        private static bool IsValidRowMove(char playerMove)
        {
            return (playerMove - 48) <= MaxRowInputValue;
        }
    }
}
