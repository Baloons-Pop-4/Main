namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface ILogger
    {
        void Info(string message, Exception exception = null);

        void Warn(string message, Exception exception = null);

        void Error(string message, Exception exception = null);

        void Fatal(string message, Exception exception = null);
    }
}
