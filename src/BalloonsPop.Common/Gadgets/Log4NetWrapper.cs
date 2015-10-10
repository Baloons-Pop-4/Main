namespace BalloonsPop.Common.Gadgets
{
    using System;
    using BalloonsPop.Common.Contracts;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// A wrapper class over Log4Net.
    /// </summary>
    public class Log4NetWrapper : ILogger
    {
        private readonly ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetWrapper" /> class.
        /// </summary>
        /// <param name="filename">The name of the file using logger.</param>
        public Log4NetWrapper(string filename)
        {
            this.logger = LogManager.GetLogger(filename);
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Log a message with the log4net.Core.Level.Debug level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Info(string message, Exception exception = null)
        {
            this.logger.Info(message, exception);
        }

        /// <summary>
        /// Log a message with the log4net.Core.Level.Warn level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Warn(string message, Exception exception = null)
        {
            this.logger.Warn(message, exception);
        }

        /// <summary>
        /// Log a message with the log4net.Core.Level.Error level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Error(string message, Exception exception = null)
        {
            this.logger.Error(message, exception);
        }

        /// <summary>
        /// Log a message with the log4net.Core.Level.Fatal level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Fatal(string message, Exception exception = null)
        {
            this.logger.Fatal(message, exception);
        }
    }
}
