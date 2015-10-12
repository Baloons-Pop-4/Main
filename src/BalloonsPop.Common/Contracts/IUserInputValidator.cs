namespace BalloonsPop.Common.Contracts
{
    /// <summary>
    /// Abstract validation provider definition for user input.
    /// </summary>
    public interface IUserInputValidator
    {
        /// <summary>
        /// Way of defining a validation over user input.
        /// </summary>
        /// <param name="userInput">The input to be validated.</param>
        /// <returns>True if the input is valid, false otherwise.</returns>
        bool IsValidUserMove(string userInput);
    }
}
