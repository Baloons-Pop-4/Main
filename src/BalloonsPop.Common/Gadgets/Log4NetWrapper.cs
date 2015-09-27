namespace BalloonsPop.Common.Gadgets
{
    using System;
    using BalloonsPop.Common.Contracts;
    using log4net;
    using log4net.Config;

    public class Log4NetWrapper : ILogger
    {
        private readonly ILog logger;

        public Log4NetWrapper(string filename)
        {
            this.logger = LogManager.GetLogger(filename);
            XmlConfigurator.Configure();
        }

        public void Debug(string message, Exception exception = null)
        {
            this.logger.Debug(message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            this.logger.Info(message, exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            this.logger.Warn(message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            this.logger.Error(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            this.logger.Fatal(message, exception);
        }
    }
}
