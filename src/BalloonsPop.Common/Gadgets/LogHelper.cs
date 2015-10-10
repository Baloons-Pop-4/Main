namespace BalloonsPop.Common.Gadgets
{
    using System.Runtime.CompilerServices;
    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// This class is used by client applications to request logger instances.
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Gets an instance of a particular instance of logger.
        /// </summary>
        /// <param name="filename">The name of the class who call the logger.</param>
        /// <returns>A particular instance of logger.</returns>
        public static ILogger GetLogger([CallerFilePath]string filename = "")
        {
            return new Log4NetWrapper(filename);
        }
    }
}
