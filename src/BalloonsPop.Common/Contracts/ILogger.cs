namespace BalloonsPop.Common.Contracts
{
    using System;

    /// <summary>
    /// Logger abstraction.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Abstract definition for information logging.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log, default value is null</param>
        void Info(string message, Exception exception = null);

        /// <summary>
        /// Abstract definition for warnings logging.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log, default value is null</param>
        void Warn(string message, Exception exception = null);

        /// <summary>
        /// Abstract definition for error logging.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log, default value is null</param>
        void Error(string message, Exception exception = null);

        /// <summary>
        /// Abstract definition for fatal error logging.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="exception">Exception to log, default value is null</param>
        void Fatal(string message, Exception exception = null);
    }
}
